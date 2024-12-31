using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Cipheres_code
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2TextBox13.Text = ""
          + " شفرة فجينير الأوتوماتيكية"
          + " هذة الشفرة تعمل على تشفير النص بنص المفتاح يضاف الية النص الاصلي"
        + "  حيث يكون فيها النص الاصلي اقصر من المفتاح مما يتيح تشفير قوي "
         + "  ويتم اضافه كل حرف يتم فك تشفيرة الى المفتاح لكي تتم عملية التشفير";
            gunaplayfair.Text = ""
        + " شفرة بلاي فير وهي من شفرات متعددة المحارف"
        + " التي تشفر الحرف باكثر من صورة "
        + " وايضا يكون التشفير فيها على بلكات ثنائية";
            PopulateBeaufortTable();
        }

        /// <summary>
        /// شفرة قيصر 
        /// ِشفرة قيصر هي من أحد اشهر أنواع التشفير الكلاسيكي
        /// حيث تتميز ببساطتها ويعيبها سهولة كسرها
        /// وتتم فيها عملية التشفير بإخذ الحرف المراد تشفيره 
        /// وعمل إزاحة له عادة بمقدار 3 وعكس الإزاحة في فك التشفير
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region Caesar Cipher
        // قيصر
        private void btnEncryption_Click(object sender, EventArgs e)
        {
            if (txtPlaintext.Text != null)
              txtCipherText.Text=  Encrypte(txtPlaintext.Text, GetValidShift((int)nud_key.Value));
        }
        //// قيصر
        private int GetValidShift(int value)
        {
            int validShift = value % 26;
            if (validShift<0)
            {
                validShift += 26;
            }
            return validShift;
        }

        //داله تشفير قيصر
        private string Encrypte(string text, int value)
        {
            string cipher_text="";
            char cipher_char;
            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    cipher_char = (char)(item + value);
                    if (char.IsUpper(item))
                    {
                        if (cipher_char>'Z')
                        {
                            cipher_char = (char)(cipher_char - 26);
                        }

                    }
                   else if (char.IsLower(item))
                    {
                        if (cipher_char > 'z')
                        {
                            cipher_char = (char)(cipher_char - 26);
                        }

                    }
                    cipher_text += cipher_char;
                }
                else { cipher_text += item; }
            }

            return cipher_text;
        }

        // قيصر
        private void btnDecryption_Click(object sender, EventArgs e)
        {
            if (txtCipherText.Text != null)

                TxtDPlainText.Text = Decrypte(txtCipherText.Text, 
                    GetValidShift((int)nud_key.Value));
        }
        //  دالة فك التشفير قيصر
        private string Decrypte(string text, int v)
        {
            string plain_text = "";
            char plain_char;
            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    plain_char = (char)(item - v);
                    if (char.IsUpper(item))
                    {
                        if (plain_char < 'A')
                        {
                            plain_char = (char)(plain_char + 26);
                        }

                    }
                    else if (char.IsLower(item))
                    {
                        if (plain_char < 'a')
                        {
                            plain_char = (char)(plain_char + 26);
                        }

                    }
                    plain_text += plain_char;
                }
                else { plain_text += item; }
            }

            return plain_text;

        }
        #endregion // شفرة قيصر    //


        /// <summary>
        /// شفرة Attbash وتكمن فكرة عملها في عكس ترتيب الحروف 
        /// وليس فيها مفتاح مستخدم , مع ملاحظة
        /// ان خوارزمية التشفير هي نفسها المستخدمة في فك التشفير 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region Attbash Cipher
        //اتباش حدث تشفير
        private void btn_Attbash_enc_Click(object sender, EventArgs e)
        {
            this.btn_Attbash_enc.Enabled = false;

            if (Attbash_Plain_txt.Text!=null)
            {
                Attbash_cipher_txt.Text = Attbash_Encrypte_Decrtypte(Attbash_Plain_txt.Text);
            } 
        }

        //دالة التشفير وفك التشفير اتباش
        private string Attbash_Encrypte_Decrtypte(string text)
        {
            string attbash_text = "";
            char attbash_char;

            foreach (char item in text)
            {
                
                if (char.IsLetter(item))
                {
                    attbash_char = (char)(item - 25);
                    if (char.IsUpper(item))
                    {
                        attbash_char = (char)('Z' - (item - 'A'));
                    }
                    else
                    {
                        attbash_char = (char)('z' - (item - 'a'));
                    }
                    attbash_text += attbash_char;   
                }
                else
                {
                    attbash_text += item;
                }
            }
            return attbash_text;
        }

        //اتباش حدث فك التشفير
        private void btn_Attbash_dec_Click(object sender, EventArgs e)
        {
            this.btn_Attbash_enc.Enabled = true;
            if (Attbash_cipher_txt.Text != null)
            {
                Attbash_DPlian_txt.Text = Attbash_Encrypte_Decrtypte(Attbash_cipher_txt.Text);
            }


        }
        #endregion


        /// <summary>
        /// بالنسبة لشفره Rot 13 فهي من  شفرات التبديل التي تحول
        /// الحرف الى الحرف الذي يلية ب13 حرف في الابجدية
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region Rot13 Ciphr
        //روت 13 حدث تشفير
        private void btn_Rot13_enc_Click(object sender, EventArgs e)
        {
            this.btn_Rot13_enc.Enabled = !true;

            if (Rot13_Plain_txt_box.Text!=null)
            {
                Rot13_Cipher_txt_box.Text = Rot13_enc_dec_method(Rot13_Plain_txt_box.Text);
            }
        }
        // دالة التشفير و فك التشفير لشفرة Rot13
        private string Rot13_enc_dec_method(string text)
        {
            string Rot13_text = "";
            char Rot13_char;

            foreach (char item in text)
            {

                if (char.IsLetter(item))
                {
                    Rot13_char = item;
                    if (char.IsUpper(item))
                    {
                        Rot13_char = (char)('A' + (item - 'A' + 13) % 26);
                    }
                    else
                    {
                        Rot13_char = (char)('a' + (item - 'a' + 13) % 26);
                    }
                    Rot13_text += Rot13_char;
                }
                else
                {
                    Rot13_text += item;
                }
            }
            return Rot13_text;
        }
        // روت 13 حدث فك التشفير
        private void btn_Rot13_dec_Click(object sender, EventArgs e)
        {
            this.btn_Rot13_enc.Enabled = true;
            if (Rot13_Cipher_txt_box.Text != null)
            {
                Rot13_DPlain_txt_box.Text = Rot13_enc_dec_method(Rot13_Cipher_txt_box.Text);
            }
        }
        #endregion


        /// <summary>
        /// AFFIN : تعتمد هذة الشفرة على فكرة التشفير المختلط 
        /// وهي مزيج من شفرة قيصر وشفرة الضرب 
        /// ويجب ان يكون معامل الضرب فيها اوليا مع العدد 26 
        /// لكي يكون للشفرة معكوس
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region Affine Cipher
        // حدث التشفير لل affin
        private void affine_btn_Click(object sender, EventArgs e)
        {
            if (check((int)nd_M.Value))
            {
                nd_M_inverse.Value = getInverse((int)nd_M.Value);
               txt_affin_cipher_text.Text = encry_affin_method((int)nd_M.Value, txt_affin_plain.Text,(int)nd_Key.Value);

            }
            else
            {
                MessageBox.Show(" the m value is not valued");

            }
        }
        // دالة فك التشفير لشفرة AFFIN
        private string decry_affin_method(int Me, string text, int key)
        {
            string aff_plain_text = "";
            char aff_plain_char;
            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    if (char.IsLower(item))
                    {
                        aff_plain_char = char.ToLower(aff_pl_char(item, Me, key));
                        aff_plain_text += aff_plain_char;

                    }
                    else
                    {
                        aff_plain_char = char.ToUpper(aff_pl_char(item, Me, key));
                        aff_plain_text += aff_plain_char;
                    }
                }

                else aff_plain_text += item;
            }
            return aff_plain_text;
        }
        //دالة فك تشفير الحرف affin
        private char aff_pl_char(char item, int me, int k)
        {
            int charvalue = char.ToUpper(item) - 'A';
            int decryptedvalue = (me *( charvalue - k + 26)) % 26;
            char decryptedchar = (char)(decryptedvalue + 'A');
            return decryptedchar;
        }
        // دالة التشفير لشفرة AFFIN
        private string encry_affin_method(int M, string text,int key)
        {
            string aff_cipher_text="";
            char aff_cipher_char;
            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    if (char.IsLower(item))
                    {
                        aff_cipher_char = char.ToLower(aff_cip_char(item, M, key));
                        aff_cipher_text += aff_cipher_char;

                    }
                    else
                    {
                        aff_cipher_char = char.ToUpper(aff_cip_char(item, M, key));
                        aff_cipher_text += aff_cipher_char;
                    }
                }

                else aff_cipher_text += item;
            }
            return aff_cipher_text;

        }

        // دالة تشفير الحرف affin
        private char aff_cip_char(char item, int m, int key)
        {
            int charvalue = char.ToUpper(item) - 'A';
            int encryptedvalue = (m * charvalue + key) % 26;
            char encryptedchar = (char)(encryptedvalue + 'A');
            return encryptedchar;
        }


        private decimal getInverse(int M)//معكوس M لمعادلة affin
        {
            decimal m_e = 0;
            for (int i = 1; ; i++)
            {
                if ((M * i) % 26 == 1)
                {
                    m_e= i;
                    break;
                    
                }
                
            }
            return m_e;
        }

        private bool check(int B)
        {
            int A = 26;
            int temp = A % B;
           
            while (temp!=0)
            {
                A = B;
                B = temp;
                temp = A % B;
            }
            if (B == 1)
             return true;
           else return false;
            
;        }

        private void btn_affin_decryption_Click(object sender, EventArgs e)
        {
            if (txt_affin_cipher_text.Text != null)
            {

                txt_affin_plain_text.Text = decry_affin_method((int)nd_M_inverse.Value, txt_affin_cipher_text.Text, (int)nd_Key.Value);

            }
            else
            {
                MessageBox.Show("there is no cipher text");

            }
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }




        #endregion


        /// <summary>
        /// Simple Vigenere Cipher  وهي أبسط انواع شفرة فجينير 
        /// حيث تعتمد على تشفير الحرف الاول بمفتاح 
        /// والثاني باخر والثالث بمفتاح اخر وهكذا 
        /// حتى يكتمل استخدام المفاتيح ثم تعاد استخدامها
        /// في دوارة حتى اخر حرف في النص
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region Vigener Cipher
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        // event add keys
        private void btn_add_key_Click(object sender, EventArgs e)
        {
            add_key_to_label_list( nd_vig_key.Value.ToString());
            add_key_to_keys_list(nd_vig_key.Value);
        }
        //list to store keys
        private List<decimal> keys = new List<decimal>();
        private void add_key_to_keys_list(decimal value)
        {
            keys.Add((value));
        }

        // إضافة المفتاح الى label
        static int key_count = 0;
        private void add_key_to_label_list(string value)
        {
            int index = lab_keys_list.Text.Length - 2;
            if (key_count == 0) lab_keys_list.Text = lab_keys_list.Text.Insert(index, value);
            else lab_keys_list.Text = lab_keys_list.Text.Insert(index, " , " + value);
            key_count++;
        }
        static int label = 0;
        private void add_key_to_label(string value)
        {

            int index = label21.Text.Length - 2;
            if (label++ == 0) label21.Text = label21.Text.Insert(index, value);
           else label21.Text = label21.Text.Insert(index, " , " + value);
        }
        // encryption event btn
        private void btn_vig_encryption_Click(object sender, EventArgs e)
        {
           
            if (txt_vig_plain.Text!=null)
            {
                txt_vig_cipher.Text = vig_encryption(txt_vig_plain.Text,keys);
            }
        }
        //encryption method for vigener cipher
        private string vig_encryption(string text, List<decimal> keys)
        {
            string ciphertext = "";
            char cipher_c;
            int keyindex = 0;
         

            foreach (char item in text)
            {
                int key =(int) keys[keyindex%keys.Count];
                add_key_to_label(key.ToString());
                key %= 26;

                if (char.IsLetter(item))
                {
                    cipher_c = (char)(item + key);
                    if (char.IsUpper(item))
                    {
                        if (cipher_c > 'Z')
                        {
                            cipher_c = (char)(cipher_c - 26);
                        }

                    }
                    else if (char.IsLower(item))
                    {
                        if (cipher_c > 'z')
                        {
                            cipher_c = (char)(cipher_c - 26);
                        }

                    }
                    ciphertext += cipher_c;
                }
                else { ciphertext += item; }
                keyindex++;
                if (keyindex==keys.Count)
                {
                    keyindex = 0;
                }
            }

            return ciphertext;
        }
        // btn decryption event vigener
        private void btn_vig_decryption_Click(object sender, EventArgs e)
        {
            if (txt_vig_cipher.Text!=null)
            {
                txt_vig_Dplain_txt.Text = vig_decryption(txt_vig_cipher.Text,keys);
            }
        }
        // decryption vigener cipher
        private string vig_decryption(string text, List<decimal> keys)
        {
            string dplaintext = "";
            char dplain_c;
            int keyindex = 0;


            foreach (char item in text)
            {
                decimal key = keys[keyindex];
                key %= 26;
                if (char.IsLetter(item))
                {
                    dplain_c = (char)(item - key);
                    if (char.IsUpper(item))
                    {
                        if (dplain_c < 'A')
                        {
                            dplain_c = (char)(dplain_c + 26);
                        }

                    }
                    else if (char.IsLower(item))
                    {
                        if (dplain_c < 'a')
                        {
                            dplain_c = (char)(dplain_c + 26);
                        }

                    }
                    dplaintext += dplain_c;
                }
                else { dplaintext += item; }
                keyindex++;
                if (keyindex == keys.Count)
                {
                    keyindex = 0;
                }
            }

            return dplaintext;
        }

        #endregion


        /// <summary>
        /// شفرة بلاي فير وهي من شفرات متعددة المحارف
        /// التي تشفر الحرف باكثر من صورة 
        /// وايضا يكون التشفير فيها على بلكات ثنائية
        /// </summary>
#region Playfair Cipher

        char[,] Key_charset = new char[5, 5];
        string alpha = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        private string message_R_T_C;

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox13_TextChanged(object sender, EventArgs e)
        {
            if (!char.IsLetter(txt_key.Text[txt_key.Text.Length-1]))
            {
                return;
            }
            Generate_Key(txt_key.Text);
        }

        private void Generate_Key(string key_phrase)
        {
            key_phrase = key_phrase.ToUpper();
            key_phrase = key_phrase.Replace(" ", "");
            key_phrase = key_phrase.Replace("J", "I");
            string Edited_key = "";
            foreach (var ch in key_phrase)
            {
                if (!Edited_key.Contains(ch))
                {
                    Edited_key += ch;
                }
            }
            foreach (var ch in alpha)
            {
                if (!Edited_key.Contains(ch))
                {
                    Edited_key += ch;
                }
            }
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Key_charset[i, j] = Edited_key[index++];
                }
            }
            guna2DataGridView1.Rows.Clear();
            for (int i = 0; i < 5; i++)
            {
                object[] ob = new object[] { Key_charset[i, 0], Key_charset[i, 1], Key_charset[i, 2], Key_charset[i, 3], Key_charset[i, 4] };
                guna2DataGridView1.Rows.Add(ob);
            }
        }


        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            Edite_Message(txt_message.Text.ToUpper());
            Encryption_Method();
            txt_cipher.Text = cipher_text;
        }
    
        private void GetXY(char ch,ref int X,ref int Y)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Key_charset[i,j]==ch)
                    {
                        X = i;
                        Y = j;
                        return;
                    }
                }
            }
        }
        private string cipher_text;
        private void Encryption_Method()
        {
            cipher_text = "";
            int X = 0, Y = 0;
            for (int i = 0; i < message_R_T_C.Length; i+=2)
            {
                int x1=0, x2=0, y1=0, y2=0;
                GetXY(message_R_T_C[i], ref x1, ref y1);
                GetXY(message_R_T_C[i+1], ref x2, ref y2);

                if (x1==x2)
                {
                    cipher_text += Key_charset[x1, (y1 + 1) % 5];
                    cipher_text += Key_charset[x2, (y2 + 1) % 5];
                }
                else if (y1==y2)
                {
                    cipher_text += Key_charset[(x1 + 1) % 5, y1];
                    cipher_text += Key_charset[(x2 + 1) % 5, y2];
                }
                else
                {
                    cipher_text += Key_charset[x1, y2];
                    cipher_text += Key_charset[x2, y1];
                }

            }
            
        }

        private void Edite_Message(string message)
        {
            message = message.Replace(" ","");
            message = message.Replace("J", "I");
            for (int i = 0; i < message.Length-1; i+=2)
            {
                if (message[i]==message[i+1])
                {
                   message= message.Insert(i+1 , "X");
                }
             
            }
            if (message.Length % 2 == 1)
            {
                message += "X";
            }
            message_R_T_C = message;
        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_decrypte_Click(object sender, EventArgs e)
        {
            txt_plain.Text = Decrypted_playfair(txt_cipher.Text);
        }
        private string plain_Playfair_text;
        private string Decrypted_playfair(string c_t)
        {
            plain_Playfair_text = "";
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < c_t.Length; i += 2)
            {
                GetXY(c_t[i], ref x1, ref y1);
                GetXY(c_t[i + 1], ref x2, ref y2);
                if (x1 == x2)
                {
                    plain_Playfair_text += Key_charset[x1, (y1 - 1 + 5) % 5];
                    plain_Playfair_text += Key_charset[x2, (y2 - 1 + 5) % 5];
                }
                else if (y1 == y2)
                {
                    plain_Playfair_text += Key_charset[(x1 - 1 + 5) % 5, y1];
                    plain_Playfair_text += Key_charset[(x2 - 1 + 5) % 5, y2];
                }
                else
                {
                    plain_Playfair_text += Key_charset[x1, y2];
                    plain_Playfair_text += Key_charset[x2, y1];
                }

            }

            return plain_Playfair_text.Replace("X", "");



        }

        #endregion


        /// <summary>
        /// شفرة فجينير الأوتوماتيكية
        /// هذة الشفرة تعمل على تشفير النص بنص المفتاح يضاف الية النص الاصلي
        /// حيث يكون فيها النص الاصلي اقصر من المفتاح مما يتيح تشفير قوي 
        /// ويتم اضافه كل حرف يتم فك تشفيرة الى المفتاح لكي تتم عملية التشفير
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#region auto vigener

        private void txt_key_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
         
        }
        string Auto_key = "";
        private void btn_encry_full_Click(object sender, EventArgs e)
        {
            Auto_key = "";
            if (txt_full_plain.Text!="")
            {
                Auto_key = txt_full_key.Text.Replace(" ","") + txt_full_plain.Text.Replace(" ", "");
                txt_Cipher_full.Text = Full_encry(txt_full_plain.Text, Auto_key);
            }
        }

        private string Full_encry(string text, string key_phrase_Ve)
        {
            string cipher_text = "";
            char ch;
            int index = 0;
            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    if (char.IsLower(item))
                    {
                        if ((item + (char.ToLower(key_phrase_Ve[index]) - 'a')) > 'z')
                        {
                            ch = (char)(item + (char.ToLower(key_phrase_Ve[index++]) - 'a') - 26);
                        }
                        else
                        {
                            ch = (char)(item + (char.ToLower(key_phrase_Ve[index++]) - 'a'));
                        }
                        cipher_text += ch;

                    }
                    else
                    {
                        if ((item + (char.ToUpper(key_phrase_Ve[index]) - 'A')) > 'Z')
                        {
                            ch = (char)(item + (char.ToUpper(key_phrase_Ve[index++]) - 'A') - 26);
                        }
                        else
                        {
                            ch = (char)(item + (char.ToUpper(key_phrase_Ve[index++]) - 'A'));
                        }
                        cipher_text += ch;

                    }
                }
                else
                {
                    cipher_text += item;
                }
                
            }
            return cipher_text;
        }

        private void txt_full_key_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_Cipher_full.Text != "")
            {
                txt_full_decipher.Text = Full_decry(txt_Cipher_full.Text, txt_full_key.Text.Replace(" ",""));
            }

        }

        private string Full_decry(string text, string key)
        {
            string auto_key = key;
            string decipher_text = "";
            char ch;
            int index = 0;
            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    if (char.IsLower(item))
                    {
                        if ((item - (char.ToLower(auto_key[index]) - 'a')) < 'a')
                        {
                            ch = (char)(item - (char.ToLower(auto_key[index++]) - 'a') + 26);
                        }
                        else
                        {
                            ch = (char)(item - (char.ToLower(auto_key[index++]) - 'a'));
                        }
                        decipher_text += ch;
                        auto_key += ch;


                    }
                    else
                    {
                        if ((item - (char.ToUpper(auto_key[index]) - 'A')) < 'A')
                        {
                            ch = (char)(item - (char.ToUpper(auto_key[index++]) - 'A') + 26);
                        }
                        else
                        {
                            ch = (char)(item - (char.ToUpper(auto_key[index++]) - 'A'));
                        }
                        decipher_text += ch;
                        auto_key += ch;
                    }
                }
                else
                {
                    decipher_text += item;
                }

            }
            return decipher_text;
        }
        private void guna2TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        /// <summary>
        ///    الشفرة الإبدالية بالأعمدة
        ///الشفرة الإبدالية بالأعمدة هي إحدى طرق التشفير التقليدية التي تعتمد
        ///على إعادة ترتيب أحرف النص الأصلي.تُكتب الأحرف في شكل مصفوفة (جدول)
        ///حيث يحدد طول الكلمة المفتاحية عدد الصفوف،
        ///ثم تُقرأ الأعمدة بترتيب محدد بناءً على الكلمة المفتاحية.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

#region Columnar Transposition Cipher
            

        // Helper function to determine the column order based on the keyword
        private int[] GetColumnOrder(string keyword)
        {
            int[] columnOrder = new int[keyword.Length];
            for (int i = 0; i < keyword.Length; i++)
            {
                columnOrder[i] = i;
            }

            Array.Sort(columnOrder, (x, y) => keyword[x].CompareTo(keyword[y]));

            return columnOrder;
        }

       
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox19_TextChanged(object sender, EventArgs e)
        {
           
                string keyword = Trans_Cipher_Key_Text_Box.Text;

                // التحقق من طول المفتاح
                if (string.IsNullOrEmpty(keyword))
                {
                    // مسح الـ DataGridView وإعادة تعيينه
                    TransdataGridView.Rows.Clear();
                    TransdataGridView.Columns.Clear();
                    return; // الخروج من الدالة إذا كان المفتاح فارغًا
                }

                string plaintext = Trans_Plain_txt.Text.Replace(" ", ""); // إزالة المسافات من النص

                // إنشاء الأعمدة
                TransdataGridView.ColumnCount = keyword.Length;
                for (int i = 0; i < keyword.Length; i++)
                {
                    TransdataGridView.Columns[i].HeaderText = keyword[i].ToString();
                }

                // حساب عدد الصفوف المطلوبة بناءً على طول النص والمفتاح
                int rows = (int)Math.Ceiling((double)plaintext.Length / keyword.Length);
                TransdataGridView.RowCount = rows; // تعيين عدد الصفوف المطلوب

                // ترتيب الأعمدة بناءً على الكلمة المفتاحية
                int[] columnOrder = GetColumnOrder(keyword);

                // ملء الـ DataGridView
                int rowIndex = 0, colIndex = 0;
                foreach (char ch in plaintext)
                {
                    if (rowIndex < rows) // تأكد من عدم تجاوز الصفوف المطلوبة
                    {
                        TransdataGridView.Rows[rowIndex].Cells[columnOrder[colIndex]].Value = ch;
                        colIndex++;
                        if (colIndex == keyword.Length)
                        {
                            rowIndex++;
                            colIndex = 0;
                        }
                    }
                }

                // تعبئة الخلايا المتبقية بحرف 'x' عند الحاجة
                while (rowIndex < rows)
                {
                    TransdataGridView.Rows[rowIndex].Cells[columnOrder[colIndex]].Value = 'x';
                    colIndex++;
                    if (colIndex == keyword.Length)
                    {
                        rowIndex++;
                        colIndex = 0;
                    }
                }
            

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            StringBuilder cipherText = new StringBuilder();

            // نمر على كل صف في الجدول
            foreach (DataGridViewRow row in TransdataGridView.Rows)
            {
                // نمر على كل خلية في الصف
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // إذا كانت الخلية تحتوي على قيمة، نضيفها إلى السلسلة
                    if (cell.Value != null)
                    {
                        cipherText.Append(cell.Value.ToString());
                    }
                }
            }

            // عرض النص المشفر في مربع النص
            Trans_Cipher_Cipher_Text_Box.Text = cipherText.ToString();
        }
        private void Trans_btn_decrypt_Click(object sender, EventArgs e)
        {
            string cipherText = Trans_Cipher_Cipher_Text_Box.Text; // النص المشفر
            string keyword = Trans_Cipher_Key_Text_Box.Text; // المفتاح

            // التحقق من صحة المفتاح والنص المشفر
            if (string.IsNullOrEmpty(keyword) || string.IsNullOrEmpty(cipherText))
            {
                MessageBox.Show("يرجى إدخال النص المشفر والمفتاح.");
                return;
            }

            // حساب عدد الصفوف بناءً على طول النص المشفر
            int rows = (int)Math.Ceiling((double)cipherText.Length / keyword.Length);
            DTransdataGridView.RowCount = rows;
            DTransdataGridView.ColumnCount = keyword.Length;

            // توزيع النص المشفر في الجدول بناءً على ترتيب الأعمدة الأصلي للمفتاح
            int index = 0;
            for (int colIndex = 0; colIndex < keyword.Length; colIndex++)
            {
                for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                {
                    if (index < cipherText.Length)
                    {
                        DTransdataGridView.Rows[rowIndex].Cells[colIndex].Value = cipherText[index++];
                    }
                }
            }
            
            // الحصول على ترتيب الأعمدة بناءً على ترتيب المفتاح (هجائياً)
            int[] columnOrder = GetColumnOrder(keyword);

            // إعادة ترتيب الأعمدة بناءً على ترتيب المفتاح

            // إعادة توزيع القيم بناءً على الترتيب الأبجدي
            for (int col = 0; col < keyword.Length; col++)
            {
                int orderedCol = columnOrder[col];
                for (int row = 0; row < rows; row++)
                {
                    DTransdataGridView.Rows[row].Cells[col].Value = TransdataGridView.Rows[row].Cells[orderedCol].Value;
                }
            }

            // قراءة النص من الصفوف بعد ترتيب الأعمدة
            StringBuilder decryptedText = new StringBuilder();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < keyword.Length; col++)
                {
                    if (DTransdataGridView.Rows[row].Cells[col].Value != null)
                    {
                        decryptedText.Append(DTransdataGridView.Rows[row].Cells[col].Value.ToString());
                    }
                }
            }

            // عرض النص المفكك
            Trans_Cipher_dCiphered_Text_Box.Text = decryptedText.ToString();
        }






        #endregion // Columnar Transposition Cipher

#region Reverse cipher
        private void Revers_btn_enc_Click(object sender, EventArgs e)
        {
            Revers_Cipher_text.Text = ReverseString(Revers_Plain_text.Text);
        }

        private string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void Revers_btn_dec_Click(object sender, EventArgs e)
        {
            Revers_dCipher_text.Text = ReverseString(Revers_Cipher_text.Text);
        }





        #endregion


#region Row Cipher
        private void Row_btn_enc_Click(object sender, EventArgs e)
        {
            string plaintext = Row_Trans_Plain_txt.Text;
            string key = Row_Trans_Cipher_Key_Text_Box .Text;

            string encryptedText = EncryptRowTransposition(plaintext, key);
            RowTrans_Cipher_Cipher_Text_Box.Text = encryptedText;

        }
        private void Row_btn_dec_Click(object sender, EventArgs e)
        {
            string cipherText = RowTrans_Cipher_Cipher_Text_Box.Text;
            string key = Row_Trans_Cipher_Key_Text_Box.Text;

            string decryptedText = DecryptRowTransposition(cipherText, key);
            RowTrans_Cipher_dCiphered_Text_Box.Text = decryptedText;
        }
        private void Row_Trans_Cipher_Key_Text_Box_TextChanged(object sender, EventArgs e)
        {
            

        }
        // Function to decrypt using Row Transposition Cipher
        private string DecryptRowTransposition(string cipherText, string key)
        {
            int keyLength = key.Length;
            int rows = (int)Math.Ceiling((double)cipherText.Length / keyLength);
            char[,] table = new char[rows, keyLength];

            // Step 1: Sort the key alphabetically
            char[] sortedKey = key.ToCharArray();
            Array.Sort(sortedKey);

            // Step 2: Fill the table column-wise based on sorted key order
            int index = 0;
            for (int col = 0; col < keyLength; col++)
            {
                int originalCol = key.IndexOf(sortedKey[col]);
                for (int row = 0; row < rows; row++)
                {
                    if (index < cipherText.Length)
                    {
                        table[row, originalCol] = cipherText[index++];
                    }
                }
            }

            // Clear and prepare DataGridView for displaying the table
            RowTransdataGridView.Columns.Clear();
            RowTransdataGridView.Rows.Clear();

            // Add columns to DataGridView for each character in key
            for (int col = 0; col < keyLength; col++)
            {
                RowTransdataGridView.Columns.Add("Col" + col, key[col].ToString());
            }

            // Add rows to DataGridView to display the table
            for (int row = 0; row < rows; row++)
            {
                string[] rowData = new string[keyLength];
                for (int col = 0; col < keyLength; col++)
                {
                    rowData[col] = table[row, col].ToString();
                }
                RowTransdataGridView.Rows.Add(rowData);
            }

            // Step 3: Read the table row-wise to reconstruct the plaintext
            string plaintext = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < keyLength; col++)
                {
                    plaintext += table[row, col];
                }
            }

            return plaintext.TrimEnd('x'); // Remove padding 'x'
        }

        // Function to encrypt using Row Transposition Cipher
        private string EncryptRowTransposition(string plaintext, string key)
        {
            // Step 1: Remove spaces and ensure plaintext length matches key length by padding with 'x'
            plaintext = plaintext.Replace(" ", "");
            int keyLength = key.Length;
            int rows = (int)Math.Ceiling((double)plaintext.Length / keyLength);
            char[,] table = new char[rows, keyLength];

            // Step 2: Fill the table row-wise with plaintext characters
            int index = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < keyLength; col++)
                {
                    if (index < plaintext.Length)
                    {
                        table[row, col] = plaintext[index++];
                    }
                    else
                    {
                        table[row, col] = 'x'; // Padding with 'x'
                    }
                }
            }

            // Clear and prepare DataGridView for displaying table
            RowTransdataGridView.Columns.Clear();
            RowTransdataGridView.Rows.Clear();

            // Add columns to DataGridView for each character in key
            for (int col = 0; col < keyLength; col++)
            {
                RowTransdataGridView.Columns.Add("Col" + col, key[col].ToString());
            }

            // Add rows to DataGridView to display the table
            for (int row = 0; row < rows; row++)
            {
                string[] rowData = new string[keyLength];
                for (int col = 0; col < keyLength; col++)
                {
                    rowData[col] = table[row, col].ToString();
                }
                RowTransdataGridView.Rows.Add(rowData);
            }

            // Step 3: Sort the key alphabetically and read column-wise based on sorted key order
            char[] sortedKey = key.ToCharArray();
            Array.Sort(sortedKey);

            string cipherText = "";
            for (int col = 0; col < keyLength; col++)
            {
                int originalCol = key.IndexOf(sortedKey[col]);
                for (int row = 0; row < rows; row++)
                {
                    cipherText += table[row, originalCol];
                }
            }

            return cipherText;
        }


        #endregion

        #region Beaufort Cipher
        private void PopulateBeaufortTable()
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            BeaufortDataGridView.ColumnCount = 26;
            BeaufortDataGridView.RowCount = 26;

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    BeaufortDataGridView.Rows[i].Cells[j].Value = alphabet[(i - j + 26) % 26];
                }
            }

            for (int i = 0; i < 26; i++)
            {
                BeaufortDataGridView.Columns[i].HeaderText = alphabet[i].ToString();
                BeaufortDataGridView.Rows[i].HeaderCell.Value = alphabet[i].ToString();
            }
        }

        

    

        // دالة التشفير/فك التشفير باستخدام شيفرة Beaufort
        private string BeaufortCipher(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int keyIndex = 0;

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    int letterPos = ch - 'A';
                    int keyPos = key[keyIndex % key.Length] - 'A';
                    char cipherChar = alphabet[(keyPos - letterPos + 26) % 26];
                    result.Append(cipherChar);
                    keyIndex++;
                }
            }

            return result.ToString();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string plaintext = BeaufortPlainTextBox.Text.ToUpper().Replace(" ", "");
            string key = BeaufortKeyTextBox.Text.ToUpper().Replace(" ", "");
            string cipherText = BeaufortCipher(plaintext, key);
            BeaufortCipherTextBox.Text = cipherText;
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string cipherText = BeaufortCipherTextBox.Text.ToUpper().Replace(" ", "");
            string key = BeaufortKeyTextBox.Text.ToUpper().Replace(" ", "");
            string plaintext = BeaufortCipher(cipherText, key); // Beaufort تشفيرها هو نفسه فك التشفير
            BeaufortPlainTextBox2.Text = plaintext;
        }
        #endregion

#region  Kasiski Examination
        // Function to find repeated sequences in the ciphertext
        private List<Tuple<string, int>> FindRepeatedSequences(string ciphertext, int minLength, int maxLength)
        {
            var repeatedSequences = new List<Tuple<string, int>>();
            var sequencePositions = new Dictionary<string, List<int>>();

            // Iterate over the ciphertext
            for (int i = 0; i < ciphertext.Length; ++i)
            {
                for (int j = minLength; j <= maxLength; ++j)
                {
                    // Extract substrings of length j
                    if (i + j <= ciphertext.Length)
                    {
                        string substring = ciphertext.Substring(i, j);

                        // Check if this substring has been seen before
                        if (sequencePositions.ContainsKey(substring))
                        {
                            // Calculate the distance between the occurrences
                            foreach (int pos in sequencePositions[substring])
                            {
                                int distance = i - pos;
                                // Ignore distances shorter than the minimum length
                                if (distance >= minLength)
                                {
                                    repeatedSequences.Add(new Tuple<string, int>(substring, distance));
                                }
                            }
                        }
                        // Record the position of this substring
                        if (!sequencePositions.ContainsKey(substring))
                        {
                            sequencePositions[substring] = new List<int>();
                        }
                        sequencePositions[substring].Add(i);
                    }
                }
            }
            return repeatedSequences;
        }

        // Function to find the greatest common divisor (GCD)
        private int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }

        // Function to find the key length using Kasiski examination
        private int FindKeyLength(List<Tuple<string, int>> repeatedSequences)
        {
            if (repeatedSequences.Count == 0) return 0;

            var distances = repeatedSequences.Select(seq => seq.Item2).ToList();

            // Find the most common divisor of the distances
            int keyLength = distances[0];
            for (int i = 1; i < distances.Count; ++i)
            {
                keyLength = GCD(keyLength, distances[i]);
            }
            return keyLength;
        }

      
     

        private void btn_analyze_Click(object sender, EventArgs e)
        {
            string ciphertext = KaistxtCiphertext.Text;

            // Find repeated sequences
            List<Tuple<string, int>> repeatedSequences = FindRepeatedSequences(ciphertext, 3, 15);

            dgvSequences.Rows.Clear();
            dgvSequences.Columns.Clear();

            // Add columns if they are not already added
            dgvSequences.Columns.Add("Sequence", "Sequence");
            dgvSequences.Columns.Add("Distance", "Distance");

            // Add rows with repeated sequences
            foreach (var seq in repeatedSequences)
            {
                dgvSequences.Rows.Add(seq.Item1, seq.Item2);
            }

            // Find the key length
            int keyLength = FindKeyLength(repeatedSequences);

            // Display the key length
            analyzed_key.Text = "Estimated Key Length: " + keyLength.ToString();
        }

        private void KaistxtCiphertext_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

#region Rail Cipher

        // Method to display the rail matrix in the DataGridView
        private void DisplayRailMatrix(char[,] rail, int rows, int cols)
        {
            Rail_dgv.Rows.Clear();
            Rail_dgv.Columns.Clear();

            for (int i = 0; i < cols; i++)
                Rail_dgv.Columns.Add("col" + i, i.ToString());

            for (int i = 0; i < rows; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(Rail_dgv);
                for (int j = 0; j < cols; j++)
                {
                    row.Cells[j].Value = rail[i, j] == '\n' ? "" : rail[i, j].ToString();
                }
                Rail_dgv.Rows.Add(row);
            }
        }
        private string EncryptRailFence(string text, int key)
        {
            char[,] rail = new char[key, text.Length];

            // Initialize matrix with '\n' (empty spaces)
            for (int i = 0; i < key; i++)
                for (int j = 0; j < text.Length; j++)
                    rail[i, j] = '\n';

            bool dirDown = false;
            int row = 0, col = 0;

            // Fill the rail matrix
            for (int i = 0; i < text.Length; i++)
            {
                if (row == 0 || row == key - 1)
                    dirDown = !dirDown;

                rail[row, col++] = text[i];

                row += dirDown ? 1 : -1;
            }

            // Construct the cipher text
            string result = "";
            for (int i = 0; i < key; i++)
                for (int j = 0; j < text.Length; j++)
                    if (rail[i, j] != '\n')
                        result += rail[i, j];

            // Display the rail matrix in DataGridView
            DisplayRailMatrix(rail, key, text.Length);

            return result;
        }

        // Function to decrypt the message using Rail Fence Cipher
        private string DecryptRailFence(string cipher, int key)
        {
            char[,] rail = new char[key, cipher.Length];

            // Initialize matrix with '\n' (empty spaces)
            for (int i = 0; i < key; i++)
                for (int j = 0; j < cipher.Length; j++)
                    rail[i, j] = '\n';

            bool dirDown = true;
            int row = 0, col = 0;

            // Mark the positions to place characters
            for (int i = 0; i < cipher.Length; i++)
            {
                if (row == 0)
                    dirDown = true;
                if (row == key - 1)
                    dirDown = false;

                rail[row, col++] = '*';

                row += dirDown ? 1 : -1;
            }

            // Place characters in the marked positions
            int index = 0;
            for (int i = 0; i < key; i++)
                for (int j = 0; j < cipher.Length; j++)
                    if (rail[i, j] == '*' && index < cipher.Length)
                        rail[i, j] = cipher[index++];

            // Construct the original text
            string result = "";
            row = 0;
            col = 0;

            for (int i = 0; i < cipher.Length; i++)
            {
                if (row == 0)
                    dirDown = true;
                if (row == key - 1)
                    dirDown = false;

                if (rail[row, col] != '*')
                    result += rail[row, col++];

                row += dirDown ? 1 : -1;
            }

            // Display the rail matrix in DataGridView
            DisplayRailMatrix(rail, key, cipher.Length);

            return result;
        }


        private void Rail_btn_enc_Click(object sender, EventArgs e)
        {
            string plaintext = Rail_Plain_text.Text;
            int key = (int)Rail_NUD.Value;

            string encryptedText = EncryptRailFence(plaintext, key);
            Rail_Cipher_text.Text = encryptedText;
        }

        private void Rail_btn_dec_Click(object sender, EventArgs e)
        {
            string cipherText = Rail_Cipher_text.Text;
            int key = (int)Rail_NUD.Value;

            string decryptedText = DecryptRailFence(cipherText, key);
            Rail_DCipher_text.Text = decryptedText;
        }
        #endregion

#region Nihilist Cipher
        private void InitializeDataGridView()
        {
            Nihilist_dgv.Columns.Clear(); // تنظيف الأعمدة أولاً إن وجدت
            Nihilist_dgv.Columns.Add("TextCharacter", "Character");
            Nihilist_dgv.Columns.Add("KeyCharacter", "Key");
            Nihilist_dgv.Columns.Add("TextPosition", "Text Position");
            Nihilist_dgv.Columns.Add("KeyPosition", "Key Position");
            Nihilist_dgv.Columns.Add("EncryptedNumber", "Encrypted Number");
        }


        private void Nihilist_btn_enc_Click(object sender, EventArgs e)
        {
            InitializeDataGridView();
            string plaintext = Nihilist_Plain_text.Text;
            string key = Nihilist_Key.Text;

            string encryptedText = EncryptNihilist(plaintext, key);
            Nihilist_Cipher_text.Text = encryptedText;
        }

        private readonly int[,] polybiusSquare = new int[5, 5]
        {
            { 11, 12, 13, 14, 15 },
            { 21, 22, 23, 24, 25 },
            { 31, 32, 33, 34, 35 },
            { 41, 42, 43, 44, 45 },
            { 51, 52, 53, 54, 55 }
        };


        // Function to get the position of a character in the Polybius square
        private int GetCharPosition(char c)
        {
            string alphabet = "abcdefghiklmnopqrstuvwxyz"; // 'j' is omitted
            int index = alphabet.IndexOf(c);
            if (index == -1) return -1; // Invalid character
            return polybiusSquare[index / 5, index % 5];
        }

        // Function to encrypt the message using Nihilist Cipher
        private string EncryptNihilist(string text, string key)
        {
            text = text.ToLower().Replace("j", "i"); // Replacing 'j' with 'i'
            key = key.ToLower().Replace("j", "i");

            int[] keyPositions = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                keyPositions[i] = GetCharPosition(key[i]);
            }

            string result = "";
            Nihilist_dgv.Rows.Clear();

            for (int i = 0; i < text.Length; i++)
            {
                int textPos = GetCharPosition(text[i]);
                if (textPos == -1) continue; // Skip invalid characters

                int keyPos = keyPositions[i % key.Length];
                int encryptedNumber = textPos + keyPos;
                result += encryptedNumber.ToString() + " ";

                // Add to DataGridView for visualization
                Nihilist_dgv.Rows.Add(text[i], key[i % key.Length], textPos, keyPos, encryptedNumber);
            }

            return result.Trim();
        }

        // Function to decrypt the message using Nihilist Cipher
        private string DecryptNihilist(string cipherText, string key)
        {
            key = key.ToLower().Replace("j", "i");
            string[] cipherNumbers = cipherText.Split(' ');

            int[] keyPositions = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                keyPositions[i] = GetCharPosition(key[i]);
            }

            string result = "";
            Nihilist_dgv.Rows.Clear();

            for (int i = 0; i < cipherNumbers.Length; i++)
            {
                if (int.TryParse(cipherNumbers[i], out int cipherNum))
                {
                    int keyPos = keyPositions[i % key.Length];
                    int decryptedNumber = cipherNum - keyPos;

                    // Find the corresponding character in the Polybius square
                    char decryptedChar = GetCharFromPosition(decryptedNumber);
                    result += decryptedChar;

                    // Add to DataGridView for visualization
                    Nihilist_dgv.Rows.Add(decryptedChar, key[i % key.Length], decryptedNumber, keyPos, cipherNum);
                }
            }

            return result;
        }

        // Function to get the character from the Polybius square based on position
        private char GetCharFromPosition(int position)
        {
            string alphabet = "abcdefghiklmnopqrstuvwxyz"; // 'j' is omitted
            for (int i = 0; i < polybiusSquare.GetLength(0); i++)
            {
                for (int j = 0; j < polybiusSquare.GetLength(1); j++)
                {
                    if (polybiusSquare[i, j] == position)
                    {
                        return alphabet[i * 5 + j];
                    }
                }
            }
            return '?'; // Return a placeholder if the position is invalid
        }

        private void Nihilist_btn_dec_Click(object sender, EventArgs e)
        {
            string cipherText = Nihilist_Cipher_text.Text;
            string key = Nihilist_Key.Text;

            string decryptedText = DecryptNihilist(cipherText, key);
            Nihilist_dCipher_text.Text = decryptedText;
        }
        #endregion

#region ADFGVX Cipher
        // Step 1: Create the Polybius square (6x6 grid)
        private readonly char[,] polybiusSquare2 = new char[6, 6]
        {
    { 'a', 'b', 'c', 'd', 'e', 'f' },
    { 'g', 'h', 'i', 'j', 'k', 'l' },
    { 'm', 'n', 'o', 'p', 'q', 'r' },
    { 's', 't', 'u', 'v', 'w', 'x' },
    { 'y', 'z', '0', '1', '2', '3' },
    { '4', '5', '6', '7', '8', '9' }
        };

        // Step 2: Define the row/column labels for Polybius square (ADFGVX)
        private readonly char[] adfgvx = { 'A', 'D', 'F', 'G', 'V', 'X' };

        // Step 3: Function to get the ADFGVX coordinates for a given character
        private string GetCoordinates(char c)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (polybiusSquare2[i, j] == c)
                    {
                        return adfgvx[i].ToString() + adfgvx[j].ToString();
                    }
                }
            }
            return "";
        }

        // Step 4: Encrypt using ADFGVX cipher (without transposition step)
        private string EncryptADFGVX(string plaintext, string key)
        {
            plaintext = plaintext.ToLower();
            string intermediateCipher = "";

            // Step 4.1: Get the Polybius coordinates for each character
            foreach (char c in plaintext)
            {

                string coordinate = GetCoordinates(c);
                intermediateCipher += coordinate;

                // إضافة البيانات إلى DataGridView لكل حرف مشفر
                ADFGVX_dgv.Rows.Add(c, coordinate, intermediateCipher);
            }

            // Step 4.2: Transpose the intermediate cipher text using the key
            return Transpose(intermediateCipher, key);
        }

        // Step 5: Transposition function (Encrypt)
        private string Transpose(string text, string key)
        {
            int keyLength = key.Length;
            int rows = (int)Math.Ceiling((double)text.Length / keyLength);
            char[,] table = new char[rows, keyLength];

            // Fill the table row-wise
            for (int i = 0; i < text.Length; i++)
            {
                table[i / keyLength, i % keyLength] = text[i];
            }

            // Sort the key alphabetically and apply transposition
            char[] sortedKey = key.ToCharArray();
            Array.Sort(sortedKey);

            string result = "";
            for (int col = 0; col < keyLength; col++)
            {
                int originalCol = Array.IndexOf(sortedKey, key[col]);
                for (int row = 0; row < rows; row++)
                {
                    result += table[row, originalCol];
                }
            }

            return result;
        }

        // Step 6: Decrypt using ADFGVX cipher
        private string DecryptADFGVX(string cipherText, string key)
        {
            // Step 6.1: Reverse the transposition
            string transposedText = ReverseTranspose(cipherText, key);

            // Step 6.2: Decrypt the Polybius square coordinates
            string result = "";
            for (int i = 0; i < transposedText.Length; i += 2)
            {
                char rowChar = transposedText[i];
                char colChar = transposedText[i + 1];

                int row = Array.IndexOf(adfgvx, rowChar);
                int col = Array.IndexOf(adfgvx, colChar);

                result += polybiusSquare2[row, col];
            }

            return result;
        }

        // Step 7: Reverse Transposition function (Decrypt)
        private string ReverseTranspose(string text, string key)
        {
            int keyLength = key.Length;
            int rows = (int)Math.Ceiling((double)text.Length / keyLength);
            char[,] table = new char[rows, keyLength];

            // Sort the key alphabetically
            char[] sortedKey = key.ToCharArray();
            Array.Sort(sortedKey);

            // Fill the table column-wise based on sorted key
            int index = 0;
            for (int col = 0; col < keyLength; col++)
            {
                int originalCol = Array.IndexOf(sortedKey, key[col]);
                for (int row = 0; row < rows; row++)
                {
                    if (index < text.Length)
                    {
                        table[row, originalCol] = text[index++];
                    }
                }
            }

            // Read the table row-wise to reconstruct the original text
            string result = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < keyLength; col++)
                {
                    result += table[row, col];
                }
            }

            return result;
        }

        // Event handler for encryption button click
        private void ADFGVX_btn_enc_Click(object sender, EventArgs e)
        {
            InitializeADFGVXDataGridView(); // Initialize the DataGridView with appropriate columns

            string plaintext = ADFGVX_plain_text.Text;
            string key = ADFGVX_key.Text;

            string encryptedText = EncryptADFGVX(plaintext, key);
            ADFGVX_Cipher_text.Text = encryptedText;
        }

        // Event handler for decryption button click
       

        // Function to initialize DataGridView columns (for displaying steps)
        private void InitializeADFGVXDataGridView()
        {
            ADFGVX_dgv.Columns.Clear(); // Clean any existing columns

            ADFGVX_dgv.Columns.Add("PlainCharacter", "Character");
            ADFGVX_dgv.Columns.Add("CipherCoordinate", "Coordinate");
            ADFGVX_dgv.Columns.Add("CipherText", "Cipher Text");
        }

        private void ADFGVX_btn_dec_Click_1(object sender, EventArgs e)
        {
            InitializeDataGridView(); // Initialize the DataGridView with appropriate columns

            string cipherText = ADFGVX_Cipher_text.Text;
            string key = ADFGVX_key.Text;

            string decryptedText = DecryptADFGVX(cipherText, key);
            ADFGVX_dCipher_text.Text = decryptedText;
        }




        #endregion

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
    

