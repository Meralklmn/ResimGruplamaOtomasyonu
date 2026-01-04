using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimGruplamaOtomasyonu
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static readonly HttpClient _http = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BaglantiTestEt();
            ResimleriListele();
        }

        // =========================
        // 1) Connection String
        // =========================
        private string ConnectionStringGetir()
        {
            return ConfigurationManager.ConnectionStrings["ResimGruplamaDb"].ConnectionString;
        }

        // =========================
        // 2) SQL Bağlantı Testi
        // =========================
        private void BaglantiTestEt()
        {
            try
            {
                string cs = ConnectionStringGetir();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                }

                MessageBox.Show("SQL bağlantısı başarılı ✅", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL bağlantısı başarısız ❌\n\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // 3) Grid'e Resimleri Çek
        // =========================
        private void ResimleriListele()
        {
            try
            {
                string cs = ConnectionStringGetir();

                string sql = @"
SELECT 
    Id,
    DosyaAdi,
    DosyaYolu,
    Hash64,
    GrupId,
    EklenmeTarihi
FROM dbo.Resim
ORDER BY EklenmeTarihi DESC;";

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }

                // Kolon başlıkları
                if (gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Caption = "ID";
                if (gridView1.Columns["DosyaAdi"] != null) gridView1.Columns["DosyaAdi"].Caption = "Dosya Adı";
                if (gridView1.Columns["DosyaYolu"] != null) gridView1.Columns["DosyaYolu"].Caption = "Dosya Yolu";
                if (gridView1.Columns["Hash64"] != null) gridView1.Columns["Hash64"].Caption = "Hash (64)";
                if (gridView1.Columns["GrupId"] != null) gridView1.Columns["GrupId"].Caption = "Grup ID";
                if (gridView1.Columns["EklenmeTarihi"] != null) gridView1.Columns["EklenmeTarihi"].Caption = "Eklenme Tarihi";

                GriddeGrupGoster();

                if (gridView1.RowCount > 0)
                {
                    gridView1.FocusedRowHandle = 0;
                    SeciliSatiriOnizle();
                }
                else
                {
                    pictureEdit1.Image = null;
                    pictureEdit1.Properties.NullText = "Önizleme yok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GriddeGrupGoster()
        {
            if (gridView1.Columns["GrupId"] == null) return;

            gridView1.ClearGrouping();
            gridView1.OptionsView.ShowGroupPanel = true;
            gridView1.Columns["GrupId"].GroupIndex = 0;
            gridView1.ExpandAllGroups();
        }

        // =========================
        // 4) Resim Ekle (sadece yol/ad kaydeder)
        // =========================
        private void ResimEkle()
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Resim Seç";
                    ofd.Filter =
                        "Resimler (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tüm Dosyalar (*.*)|*.*";
                    ofd.Multiselect = false;

                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;

                    string dosyaYolu = ofd.FileName;
                    string dosyaAdi = Path.GetFileName(dosyaYolu);

                    string cs = ConnectionStringGetir();

                    string sql = @"
INSERT INTO dbo.Resim (DosyaAdi, DosyaYolu, Hash64, GrupId, EklenmeTarihi)
VALUES (@DosyaAdi, @DosyaYolu, NULL, NULL, SYSDATETIME());";

                    using (SqlConnection con = new SqlConnection(cs))
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@DosyaAdi", dosyaAdi);
                        cmd.Parameters.AddWithValue("@DosyaYolu", dosyaYolu);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    ResimleriListele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim ekleme hatası:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // 5) Seçili satırı önizle
        // =========================
        private void SeciliSatiriOnizle()
        {
            try
            {
                if (gridView1.FocusedRowHandle < 0)
                    return;

                object yolObj = gridView1.GetFocusedRowCellValue("DosyaYolu");
                string yol = yolObj?.ToString();

                if (string.IsNullOrWhiteSpace(yol) || !File.Exists(yol))
                {
                    pictureEdit1.Image = null;
                    pictureEdit1.Properties.NullText = "Önizleme yok";
                    return;
                }

                pictureEdit1.Image = ResmiKilitOlmadanYukle(yol);
            }
            catch
            {
                pictureEdit1.Image = null;
                pictureEdit1.Properties.NullText = "Önizleme yok";
            }
        }

        private Image ResmiKilitOlmadanYukle(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                ms.Position = 0;
                return Image.FromStream(ms);
            }
        }

        // =========================
        // 6) GEMINI - API KEY
        // =========================
        private string GeminiApiKeyGetir()
        {
            return ConfigurationManager.AppSettings["AI_API_KEY"];
        }

        private static string GuessMimeType(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();
            switch (ext)
            {
                case ".jpg":
                case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".bmp": return "image/bmp";
                case ".gif": return "image/gif";
                default: return "application/octet-stream";
            }
        }

        // =========================
        // 7) Gemini’den KATEGORİ etiketi al
        // =========================
        private async Task<string> GeminiKategoriEtiketiGetirAsync(string imagePath)
        {
            string apiKey = GeminiApiKeyGetir();
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new Exception("AI_API_KEY bulunamadı. App.config içine ekle: <add key=\"AI_API_KEY\" value=\"...\" />");

            if (!File.Exists(imagePath))
                throw new Exception("Resim dosyası bulunamadı: " + imagePath);

            // Güncel model (free tier genelde burada)
            string model = "gemini-2.5-flash";
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={apiKey}";

            byte[] bytes = File.ReadAllBytes(imagePath);
            string base64 = Convert.ToBase64String(bytes);
            string mime = GuessMimeType(imagePath);

            var payload = new
            {
                contents = new object[]
                {
                    new
                    {
                        parts = new object[]
                        {
                            new
                            {
                                text =
                                "Bu görseli 1-3 kelimelik TÜRKÇE kategori etiketiyle sınıflandır. " +
                                "Sadece etiketi yaz. Örnek: Manzara, İnsan, Bina, Araç, Hayvan, Yemek, Belge, EkranGörüntüsü, Ürün."
                            },
                            new
                            {
                                inline_data = new
                                {
                                    mime_type = mime,
                                    data = base64
                                }
                            }
                        }
                    }
                }
            };

            string json = JsonSerializer.Serialize(payload);

            // 429 gelirse otomatik retry (max 5 kez)
            for (int attempt = 1; attempt <= 5; attempt++)
            {
                using (var req = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    req.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (HttpResponseMessage resp = await _http.SendAsync(req))
                    {
                        string body = await resp.Content.ReadAsStringAsync();

                        if (resp.IsSuccessStatusCode)
                        {
                            using (JsonDocument doc = JsonDocument.Parse(body))
                            {
                                var root = doc.RootElement;
                                var candidates = root.GetProperty("candidates");
                                if (candidates.GetArrayLength() == 0) return null;

                                var text = candidates[0]
                                    .GetProperty("content")
                                    .GetProperty("parts")[0]
                                    .GetProperty("text")
                                    .GetString();

                                return (text ?? "").Trim();
                            }
                        }

                        // TooManyRequests -> bekle ve dene
                        if ((int)resp.StatusCode == 429)
                        {
                            await Task.Delay(15000); // 15 sn
                            continue;
                        }

                        throw new Exception("Gemini hata: " + resp.StatusCode + "\n\n" + body);
                    }
                }
            }

            throw new Exception("Gemini kota/limit nedeniyle yanıt vermedi (429). Biraz bekleyip tekrar dene.");
        }

        // =========================
        // 8) DB: GrupId getir/yoksa oluştur
        // =========================
        private int GrupIdGetirVeyaOlustur(SqlConnection con, SqlTransaction tx, string grupAdi)
        {
            // varsa getir
            using (SqlCommand cmdSel = new SqlCommand("SELECT TOP 1 Id FROM dbo.ResimGrubu WHERE GrupAdi = @ad;", con, tx))
            {
                cmdSel.Parameters.AddWithValue("@ad", grupAdi);
                object o = cmdSel.ExecuteScalar();
                if (o != null && o != DBNull.Value)
                    return Convert.ToInt32(o);
            }

            // yoksa oluştur
            using (SqlCommand cmdIns = new SqlCommand(@"
INSERT INTO dbo.ResimGrubu (GrupAdi, OlusturmaTarihi)
OUTPUT INSERTED.Id
VALUES (@ad, SYSDATETIME());", con, tx))
            {
                cmdIns.Parameters.AddWithValue("@ad", grupAdi);
                return Convert.ToInt32(cmdIns.ExecuteScalar());
            }
        }

        // =========================
        // 9) GEMINI'YE GÖRE GRUPLA
        // =========================
        private async Task GeminiyeGoreGruplaAsync(Action<int, int> progress = null)
        {
            string cs = ConnectionStringGetir();

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT Id, DosyaYolu FROM dbo.Resim ORDER BY Id ASC;", con))
            {
                da.Fill(dt);
            }

            int toplam = dt.Rows.Count;
            if (toplam == 0)
            {
                MessageBox.Show("Veritabanında resim yok.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int islenen = 0;
            int atlanan = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                await con.OpenAsync();

                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        // FK hatası olmaması için sadece Resim.GrupId sıfırla
                        using (SqlCommand cmdReset = new SqlCommand("UPDATE dbo.Resim SET GrupId = NULL;", con, tx))
                            await cmdReset.ExecuteNonQueryAsync();

                        var labelToGroupId = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            progress?.Invoke(i + 1, toplam);
                            await Task.Yield(); // UI güncellensin

                            int id = Convert.ToInt32(dt.Rows[i]["Id"]);
                            string yol = dt.Rows[i]["DosyaYolu"]?.ToString();

                            if (string.IsNullOrWhiteSpace(yol) || !File.Exists(yol))
                            {
                                atlanan++;
                                continue;
                            }

                            string label = await GeminiKategoriEtiketiGetirAsync(yol);
                            label = (label ?? "Diğer").Trim();
                            if (label.Length > 50) label = label.Substring(0, 50);
                            if (string.IsNullOrWhiteSpace(label)) label = "Diğer";

                            if (!labelToGroupId.TryGetValue(label, out int grupId))
                            {
                                grupId = GrupIdGetirVeyaOlustur(con, tx, label);
                                labelToGroupId[label] = grupId;
                            }

                            using (SqlCommand cmdUpd = new SqlCommand("UPDATE dbo.Resim SET GrupId=@gid WHERE Id=@id;", con, tx))
                            {
                                cmdUpd.Parameters.AddWithValue("@gid", grupId);
                                cmdUpd.Parameters.AddWithValue("@id", id);
                                await cmdUpd.ExecuteNonQueryAsync();
                            }

                            islenen++;
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

            ResimleriListele();

            MessageBox.Show(
                $"Gemini ile gruplama tamamlandı ✅\n\nToplam: {toplam}\nİşlenen: {islenen}\nAtlanan: {atlanan}",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================
        // BUTTON EVENTLERİ
        // =========================
        private void btnSqlTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BaglantiTestEt();
        }

        private void btnResimleriListele_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResimleriListele();
        }

        private void btnResimEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResimEkle();
        }

        private void btnResimSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
                return;

            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                string cs = ConnectionStringGetir();

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Resim WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                pictureEdit1.Image = null;
                pictureEdit1.Properties.NullText = "Önizleme yok";

                ResimleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatası:\n" + ex.Message);
            }
        }

        private async void btnGrupla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string eskiCaption = btnGrupla.Caption;

            try
            {
                btnGrupla.Enabled = false;
                btnGrupla.Caption = "Gruplama başlıyor...";
                this.Cursor = Cursors.WaitCursor;

                await GeminiyeGoreGruplaAsync((done, total) =>
                {
                    btnGrupla.Caption = $"Grupluyor... {done}/{total}";
                });

                btnGrupla.Caption = "Bitti ✅";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gruplama hatası:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGrupla.Enabled = true;
                btnGrupla.Caption = eskiCaption;
            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SeciliSatiriOnizle();
        }

        private void rpgVeritabani(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e) { }
        private void gridControl1_Click(object sender, EventArgs e) { }
        private void pictureEdit1_EditValueChanged(object sender, EventArgs e) { }
    }
}
