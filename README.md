# quan
mysql workbench indirip kurmalısın ( https://www.mysql.com/products/workbench/ )
------------------------------------------------
veri tabanı şifresi Usmanım
--------------

--database oluşturuyoruz--
   create database ogrenci
---------------------------------
   
   
--oluşturduğumuz databaseyi kullanıyoruz--
  use ogrenci
   
------------------------------------
   
--tablo oluşturmalısın--
    CREATE TABLE ogrenci.ogrenci (
      id INT NOT NULL AUTO_INCREMENT,
      numara INT NOT NULL,
      ad VARCHAR(45) NOT NULL,
      soyad VARCHAR(45) NOT NULL,
      telefon VARCHAR(45) NOT NULL,
      PRIMARY KEY (id));
      
----------------------------

--bir veri ekleyelim --

INSERT INTO ogrenci.ogrenci (numara, ad, soyad, telefon) VALUES ('6925', 'osman', 'kandemir', '05060637610');
