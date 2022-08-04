using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace quan
{
    internal class DBHelpers
    {
        public MySqlConnection con = new MySqlConnection("Server = localhost; Database = ogrenci; Uid = root; Pwd = 'Usmanım'; ");

        public string save()
        {
            try
            {
                List<Ogrenci> OgrenciListesi = new List<Ogrenci>();
                Console.WriteLine("kaç veri girmek istiyorsunuz");

                int deger = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < deger; i++)
                {
                    Ogrenci ogr = new Ogrenci();
                    b:
                    try
                    {
                        Console.WriteLine(i + ". numarasını griiniz");
                        ogr.Numara = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException err )
                    {
                        Console.WriteLine("!!!!!!!!!!!!!!!");
                        Console.WriteLine(err.Message);
                        Console.WriteLine("!!!!!!!!!!!!!!!");
                    ssss:
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("NE YAPMAK İSTİYORSUN");
                        Console.WriteLine("1--VERİLERİ TEKRAR GİRMEK");
                        Console.WriteLine("2--ÇIKIŞ YAPMAK");
                        Console.WriteLine("--------------------------");
                        string xx = Console.ReadLine();
                        if (xx == "1") { goto b; }
                        else if (xx == "2") { Environment.Exit(0); }
                        else
                        {
                            Console.WriteLine("Hatalı bir veri girdiniz...");
                            goto ssss;
                        }

                    }
                    

                    vvv:
                    Console.WriteLine(i + ". ad griiniz");
                    ogr.Ad = Convert.ToString(Console.ReadLine());
                    if (String.IsNullOrEmpty(ogr.Ad))
                    {
                    sss:
                        Console.WriteLine("Hatalı bir veri girdiniz...");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("NE YAPMAK İSTİYORSUN");
                        Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                        Console.WriteLine("2--ÇIKIŞ YAPMAK");
                        Console.WriteLine("--------------------------");
                        string xx = Console.ReadLine();
                        if (xx == "1") { goto vvv; }
                        else if (xx == "2") { Environment.Exit(0); }
                        else
                        {
                            Console.WriteLine("Hatalı bir veri girdiniz...");
                            goto sss;
                        }
                    }

                    vv:
                    Console.WriteLine(i + ". soyad griiniz");
                    ogr.Soyad = Convert.ToString(Console.ReadLine());
                    if (String.IsNullOrEmpty(ogr.Soyad))
                    {
                    ss:
                        Console.WriteLine("Hatalı bir veri girdiniz...");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("NE YAPMAK İSTİYORSUN");
                        Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                        Console.WriteLine("2--ÇIKIŞ YAPMAK");
                        Console.WriteLine("--------------------------");
                        string xx = Console.ReadLine();
                        if (xx == "1") { goto vv; }
                        else if (xx == "2") { Environment.Exit(0); }
                        else
                        {
                            Console.WriteLine("Hatalı bir veri girdiniz...");
                            goto ss;
                        }
                    }
                    v:
                    Console.WriteLine(i + ". tel griiniz");
                    ogr.Telefon = Convert.ToString(Console.ReadLine());
                    if (String.IsNullOrEmpty(ogr.Telefon))
                    {
                    s:
                        Console.WriteLine("Hatalı bir veri girdiniz...");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("NE YAPMAK İSTİYORSUN");
                        Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                        Console.WriteLine("2--ÇIKIŞ YAPMAK");
                        Console.WriteLine("--------------------------");
                        string xx = Console.ReadLine();
                        if (xx == "1") { goto v; }
                        else if (xx == "2") { Environment.Exit(0); }
                        else
                        {
                            Console.WriteLine("Hatalı bir veri girdiniz...");
                            goto s;
                        }
                    }


                    OgrenciListesi.Add(ogr);
                }
                Console.Clear();


                string sqll = "insert into ogrenci.ogrenci(numara,ad,soyad,telefon) values (@x,@y,@z,@t)";
                MySqlCommand cmd = new MySqlCommand(sqll, con);
                cmd.Connection = con;
                for (int i = 0; i < OgrenciListesi.Count; i++)
                {
                con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@x", OgrenciListesi[i].Numara);
                    cmd.Parameters.AddWithValue("@y", OgrenciListesi[i].Ad);
                    cmd.Parameters.AddWithValue("@z", OgrenciListesi[i].Soyad);
                    cmd.Parameters.AddWithValue("@t", OgrenciListesi[i].Telefon);
                    cmd.ExecuteNonQuery();
                con.Close();
                }
                return "YES BABEEE";


            }
            catch (Exception ex)
            {

                return "hop dostum! bir şeyler yanlış gitti" + ex.Message;
            }
        }

            public List<Ogrenci> get()
            {
                List<Ogrenci> OgrenciListesi = new List<Ogrenci>();
                string sql = "SELECT * FROM ogrenci";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ogrenci ogr = new Ogrenci();
                    ogr.Id = Convert.ToInt32(dr[0]);
                    ogr.Numara = Convert.ToInt32(dr[1]);
                    ogr.Ad = dr[2].ToString();
                    ogr.Soyad = dr[3].ToString();
                    ogr.Telefon = dr[4].ToString();
                    OgrenciListesi.Add(ogr);
                }
                con.Close();
                return OgrenciListesi;
            }

        }
    }

