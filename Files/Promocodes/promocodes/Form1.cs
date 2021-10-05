using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace promocodes
{
    public partial class Form1 : Form
    {
        string path => $"promocodes-{comboBox1.Text.ToLower()}.txt";


        int year = 0;
        bool isYearCorrect = false;

        int month = 0;
        bool isMonthCorrect = false;

        int day1 = 0;
        bool isDay1Correct = false;

        int day2 = 0;
        bool isDay2Correct = false;

        int maxDay = 0;

        int id = 0;
        bool isIdCorrect = false;

        int minCount = 0;
        bool isMinCountCorrect = false;

        int maxCount = 0;
        bool isMaxCountCorrect = false;

        int promoCodes = 0;
        bool isPromoCodesCorrect = false;

        bool write = false;
        bool reWriteFile = false;

        Random r = new Random();



        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isYearCorrect = int.TryParse(textBox1.Text, out year);

            if (year < 2020 || year > 2055)
                isYearCorrect = false;

            textBox1.BackColor = isYearCorrect ? Color.Green : Color.Red;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            isMonthCorrect = int.TryParse(textBox2.Text, out month);

            if (month < 1 || month > 12)
                isMonthCorrect = false;

            if (isMonthCorrect)
            {
                int max = 0;
                switch (month)
                {
                    case 1:
                        max = 31;
                        break;

                    case 2:
                        max = year % 4 == 0 ? 29 : 28;
                        break;

                    case 3:
                        max = 31;
                        break;

                    case 4:
                        max = 30;
                        break;

                    case 5:
                        max = 31;
                        break;

                    case 6:
                        max = 30;
                        break;

                    case 7:
                        max = 31;
                        break;

                    case 8:
                        max = 31;
                        break;

                    case 9:
                        max = 30;
                        break;

                    case 10:
                        max = 31;
                        break;

                    case 11:
                        max = 30;
                        break;

                    case 12:
                        max = 31;
                        break;
                }

                SetMaxDay(max);
            }

            month = month * 3 - 1;
            
            textBox2.BackColor = isMonthCorrect ? Color.Green : Color.Red;
        }

        private void SetMaxDay(int max)
        {
            maxDay = max;

            ReCheckDays();
        }

        private void ReCheckDays()
        {
            if (day1 < 1 || day1 > maxDay || !isMonthCorrect)
                isDay1Correct = false;

            if (day2 < 1 || day2 > maxDay || !isMonthCorrect)
                isDay2Correct = false;

            textBox3.BackColor = isDay1Correct ? Color.Green : Color.Red;
            textBox4.BackColor = isDay2Correct ? Color.Green : Color.Red;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            isDay1Correct = int.TryParse(textBox3.Text, out day1);

            ReCheckDays();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            isDay2Correct = int.TryParse(textBox4.Text, out day2);

            if (day2 < day1)
                isDay2Correct = false;

            ReCheckDays();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isIdCorrect = comboBox1.SelectedIndex != -1;
            id = comboBox1.SelectedIndex;

            id += r.Next(0, 6) * 7;
            if (id > 35) id -= 7;

            textBox5_TextChanged(null, null);
            textBox6_TextChanged(null, null);

            switch(id % 7)
            {
                case 0:
                    textBox6.Text = textBox5.Text = 30000.ToString();
                    break;

                case 1:
                    textBox6.Text = textBox5.Text = 30.ToString();
                    break;

                case 2:
                    textBox6.Text = textBox5.Text = 5.ToString();
                    break;

                case 3:
                    textBox6.Text = textBox5.Text = 1.ToString();
                    break;

                case 4:
                    textBox6.Text = textBox5.Text = 1.ToString();
                    break;

                case 5:
                    textBox6.Text = textBox5.Text = 5.ToString();
                    break;

                case 6:
                    textBox6.Text = textBox5.Text = 5.ToString();
                    break;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            isMinCountCorrect = int.TryParse(textBox5.Text, out minCount);

            textBox6_TextChanged(null, null);

            if (minCount < 1)
            {
                isMinCountCorrect = false;
            }

            textBox5.BackColor = isMinCountCorrect ? Color.Green : Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isYearCorrect && isMonthCorrect && isDay1Correct && isDay2Correct &&
                isIdCorrect && isMinCountCorrect && isMaxCountCorrect && 
                isPromoCodesCorrect)
            {
                int count = promoCodes;
                textBox8.Text = "";

                if(reWriteFile && write)
                {
                    File.Create(path).Close(); 
                }

                while (count-- > 0)
                {
                    int num = r.Next(minCount, maxCount + 1);
                    //num = num1*36*36 + num2*36 + num1;
                    int num1 = 0;
                    int num2 = 0;
                    int num3 = 0;

                    while(num-- > 0)
                    {
                        num3++;
                        if(num3 > 35)
                        {
                            num3 = 0;
                            num2++;

                            if(num2 > 35)
                            {
                                num2 = 0;
                                num1++;
                            }
                        }
                    }

                    int n1 = 0;
                    int n2 = year - 2020;
                    int n3 = num1;
                    int n4 = r.Next(0, 36);

                    int n5 = 0;
                    int n6 = month;
                    int n7 = r.Next(0, 36);
                    int n8 = id;

                    int n9 = 0;
                    int n10 = year - 2020;
                    int n11 = r.Next(0, 36);
                    int n12 = 0;
                    
                    int n13 = r.Next(0, 36);
                    int n14 = day1 + 4;
                    int n15 = num2;
                    int n16 = r.Next(0, 36);

                    int n17 = r.Next(0, 36);
                    int n18 = day2 + 3;
                    int n19 = num3;
                    int n20 = r.Next(0, 36);

                    int cs1 = n2 + n6 + n6 + n8 + n11 + n14 + n15 + n16 + n19 + n20;
                    cs1 = cs1 * 3;

                    int cs2 = n3 + n4 + n6 + n7 + n10 + n13 + n15 + n17 + n18 + n18;
                    cs2 = cs2 * 3;

                    while(cs1-- > 0)
                    {
                        n5++;

                        if(n5 > 35)
                        {
                            n5 = 0;
                            n1++;
                        }
                    }

                    while (cs2-- > 0)
                    {
                        n12++;

                        if (n12 > 35)
                        {
                            n12 = 0;
                            n9++;
                        }
                    }


                    StringBuilder sb = new StringBuilder();


                    string line1 = $"{GetSymbol(n1)}{GetSymbol(n2)}{GetSymbol(n3)}{GetSymbol(n4)}";

                    string line2 = $"{GetSymbol(n5)}{GetSymbol(n6)}{GetSymbol(n7)}{GetSymbol(n8)}";

                    string line3 = $"{GetSymbol(n9)}{GetSymbol(n10)}{GetSymbol(n11)}{GetSymbol(n12)}";

                    string line4 = $"{GetSymbol(n13)}{GetSymbol(n14)}{GetSymbol(n15)}{GetSymbol(n16)}";

                    string line5 = $"{GetSymbol(n17)}{GetSymbol(n18)}{GetSymbol(n19)}{GetSymbol(n20)}";

                    sb.Append(line1);
                    sb.Append('-');
                    sb.Append(line2);
                    sb.Append('-');
                    sb.Append(line3);
                    sb.Append('-');
                    sb.Append(line4);
                    sb.Append('-');
                    sb.Append(line5);


                    sb.AppendLine();
                    textBox8.Text += sb.ToString();
                    if(write)
                    AddPromoCode(sb.ToString());
                }
            }
        }

        private void AddPromoCode(string promoCode)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();

            }

            string[] str = new string[] { promoCode };

            File.AppendAllLines(path, str);
        }

        private char GetSymbol(int code)
        {
            switch (code)
            {
                case 0: return '0';
                case 1: return '1';
                case 2: return '2';
                case 3: return '3';
                case 4: return '4';
                case 5: return '5';
                case 6: return '6';
                case 7: return '7';
                case 8: return '8';
                case 9: return '9';
                case 10: return 'A';
                case 11: return 'B';
                case 12: return 'C';
                case 13: return 'D';
                case 14: return 'E';
                case 15: return 'F';
                case 16: return 'G';
                case 17: return 'H';
                case 18: return 'I';
                case 19: return 'J';
                case 20: return 'K';
                case 21: return 'L';
                case 22: return 'M';
                case 23: return 'N';
                case 24: return 'O';
                case 25: return 'P';
                case 26: return 'Q';
                case 27: return 'R';
                case 28: return 'S';
                case 29: return 'T';
                case 30: return 'U';
                case 31: return 'V';
                case 32: return 'W';
                case 33: return 'X';
                case 34: return 'Y';
                case 35: return 'Z';
            }

            throw new Exception("char GetSymbol(int code) Error Code!");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            isMaxCountCorrect = int.TryParse(textBox6.Text, out maxCount);

            if (maxCount < minCount)
                isMaxCountCorrect = false;

            if (maxCount > 40000)
                isMaxCountCorrect = false;

            textBox6.BackColor = isMaxCountCorrect ? Color.Green : Color.Red;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            isPromoCodesCorrect = int.TryParse(textBox7.Text, out promoCodes);

            textBox7.BackColor = isPromoCodesCorrect ? Color.Green : Color.Red;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            textBox1.Text = dt.Year.ToString();
            textBox2.Text = dt.Month.ToString();
            textBox3.Text = dt.Day.ToString();
            textBox4.Text = dt.Day.ToString();
            comboBox1.SelectedIndex = 0;
            textBox5.Text = 1000.ToString();
            textBox6.Text = 1000.ToString();
            textBox7.Text = 1.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            write = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            reWriteFile = checkBox2.Checked;
        }
    }
}
