using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace quan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            DBHelpers x=new DBHelpers();
        bas:
            Console.WriteLine("-------------------");
            Console.WriteLine("NE YAPMAK İSTİYORSUN");
            Console.WriteLine("1--veri girmek");
            Console.WriteLine("2--veri görmek");
            Console.WriteLine("3--çıkış yapmak");
            Console.WriteLine("-------------------");
            string aa=Console.ReadLine();
            Console.WriteLine("-------------------");
            if (aa == "1")
            {
                Console.WriteLine(x.save().ToString());
                goto bas;
            }
            else if (aa == "2") 
            {
                Console.WriteLine("ıd----ad----soyad----numara----telefon");
                foreach (var a in x.get())
                {
                    Console.WriteLine(" " + a.Id + " " + a.Ad + "  " + a.Soyad + "  " + a.Numara + "  " + a.Telefon);
                }
                goto bas;
            }
            else if (aa == "3") { Environment.Exit(0); }
            else 
            {
                Console.WriteLine("hatalı giriş yaptınız");
                goto bas;
            }
            // MySqlConnection con1 = new MySqlConnection();
            //con1 = x.con;
            
        }
    }
}
