USE best_logistic

CREATE TABLE dbo.point
(
	place_id varchar(255),
	[name] varchar(255),
	address varchar(511),
	postcode char(5),
	state_code char(3),
	PRIMARY KEY (place_id),
	FOREIGN KEY (state_code) REFERENCES dbo.[state]
)

INSERT INTO point (name, address, postcode, state_code, place_id) VALUES 
('Batu Pahat','No. 8, Jalan Perniagaan Ceria 1, Pusat Pernigaan Ceria, 83000 Batu Pahat, Johor.', '83000', 'JHR', 'ChIJVVVVVSpR0DERcPuZBXfrHLw'),
('Johor Bahru','No.24, Jalan Angkasa Mas Utama, Tebrau II Industrial Estate, 81100 Johor Bahru, Johor.', '81100', 'JHR', 'ChIJTfBUxjVs2jER3vZ-g6U8JkI'),
('Kluang','No. 8, Jln Intan 1/1, Tmn Intan, 86000 Kluang, Johor.', '86000', 'JHR', 'ChIJjQFqIy5s0DER6XHxU0SEqRE'),
('Muar','No. 55-11, Ground Floor, Jln Bentayan, 84000 Muar, Johor.', '84000', 'JHR', 'ChIJ-ygCArG50TERLKLyTUldfJU'),
('Pontian','No. 23G, Jalan Delima 2, Pusat Perdagangan, 82000 Pontian, Johor.', '82000', 'JHR', 'ChIJA318op2i0DERQbuEb2DSndw'),
('Senai','No. 113 & 114, Ground Floor, Jalan Impian Senai 2, 81400 Senai, Johor.', '81400', 'JHR', 'ChIJleX34Nlw2jER3F4eViNEtyg'),
('Segamat','264-A (PTD 21175) Ground Floor, Jalan Dato ''Syed Abdul Kadir, Kampung Abdullah, 85000 Segamat, Johor.', '85000', 'JHR', 'ChIJ1QQtJT3TzzER5Hm6Njb1_0Q'),
('Skudai','No. 26 & 28, Jalan Bestari 4, Taman Industri Jaya, 81300 Skudai, Johor.', '81300', 'JHR', 'ChIJwW6mVF5z2jERiwIoqaWK2l4'),
('Ulu Tiram','​No. 33, Jalan Cemerlang, Taman Perindustrian Cemerlang, 81800 Ulu Tiram, Johor Bahru.', '81800', 'JHR', 'ChIJWStES01p2jERnySvIlhowIA'),
('Bukit Pasir','​​No 40, Ground Floor, Jalan Perdagangan, Pusat Perdagangan Bukit Pasir Sg Raya, 84300 Muar, Johor.', '84300', 'JHR', 'ChIJfYKLB6PJ0TERjVrrj1g_r0s'),
('Permas Jaya','15B Jalan Permas 10/7, Bandar Baru Permas Jaya, 81750, Masai, Johor.', '81750', 'JHR', 'ChIJF4HjsZhs2jERb_mZZmL995s'),
('Pasir Gudang','No.17, Jalan Bukit 5, Kawasan MIEL Bandar Seri Alam Fasa 5, 81750 Masai, Johor', '81750', 'JHR', 'ChIJXWaORw9r2jEREsV01pHMxbg'),
('Pasir Gudang','No. 8, Jalan Serangkai 2,  Off Jalan Persiaraan Dahlia 2, Taman Bukit Dahlia, 81700 Pasir Gudang, Johor.', '81700', 'JHR', 'ChIJ4W4Yachq2jER16GwwDX8Cu8'),
('Kulai','No.76, Jalan SME 3, Kawasan Perindustrian SME, Bandar Indahpura, 81000 Kulai, Johor.', '81000', 'JHR', 'ChIJfSTQKvp52jEReaiM9cjArf4'),
('Alor Setar','No. 419, Jalan Perusahaan 6, Taman Bandar Baru, 05150 Alor Setar, Kedah.', '05150', 'KDH', 'ChIJe85TQNVDSzAR5HG0K4LSjWM'),
('Jitra','23, Plaza Seri Tunku, Jalan Tok Jalai, Jenan, 06000 Jitra, Kedah.', '06000', 'KDH', 'ChIJ_0Z31YpZSzARRONZhlOTHqY'),
('Sungai Petani','No 40, Jalan Sekerat, 08000 Sungai Petani, Kedah.', '08000', 'KDH', 'ChIJeStXGsnXSjARrfb9XRI-qyA'),
('Kulim','No. 11 & 12, Jalan Sepadu Indah 1, Taman Sepadu Indah, 09600 Lunas, Kedah.', '09600', 'KDH', 'ChIJXdP6g2fNSjARthws46Kscgg'),
('Alor Setar','No 132, Tingkat Bawah, Taman Perindustrian Kristal 2, 05150 Alor Setar, Kedah.', '05150', 'KDH', 'ChIJXdMw91NbSzARVBeixYPPagc'),
('Kota Bharu','5315-A, Jln Sultan Yahya Petra, 15200 Kota Bharu, Kelantan.', '15200', 'KTN', 'ChIJiVapgc-vtjER0XiiO71HU_U'),
('Machang','PT B 1319, Bangunan Kedai Taman Sri Intan, Jalan Besar Kweng Hitam, 18500 Machang, Kelantan.', '18500', 'KTN', 'ChIJcWqjSNGatjERgYLpSnGmYQ4'),
('Melor','No. 6, Tingkat Bawah Wisma Haji Razali, Kg Jambu Merah, Melor, 16400 Kota Bharu, Kelantan.', '16400', 'KTN', 'ChIJCdEgPvq8tjERR9iGS1rHx8o'),
('Pasir Mas','No.1 Lot 525 A,B,C, Kg. Sakar Tendong 17030, Pasir Mas, Kelantan.', '17030', 'KTN', 'ChIJHa7rmfCltjER-8gttO9YFEQ'),
('Cheras','No. 24 & 26, Jalan Cerapu, Off 3 1/4 Mile, Jln Cheras, 56100 Cheras, Kuala Lumpur.', '56100', 'KUL', 'ChIJRb7LRg02zDERETaXXhc-QyU'),
('Kepong','1, 1-1 Permata Magna Jalan Metro 2, Off Jln Kepong, 52100 Kepong, Kuala Lumpur.', '52100', 'KUL', 'ChIJ44kF-mpGzDERu0nfM3WTuDs'),
('Wangsa Maju','No 33, Jalan Wangsa Maju Delima 5, Tmn KLSC Pusat Bandar Wangsa Maju, 53300 Wangsa Maju, Kuala Lumpur.', '53300', 'KUL', 'ChIJAQAAQCU4zDER3V4T652ZBrU'),
('Sungai Besi','No. 7-3 & 7-4, Batu 2, Jln Sg Besi, 57100, Kuala Lumpur.', '57100', 'KUL', 'ChIJAQhk_yE2zDERXP2DMabyd4s'),
('Malim Jaya','30, Jalan Abadi 4, Tmn Malim Jaya, 75250 Malim, Melaka.', '75250', 'MLK', 'ChIJpRf75Avw0TERf4_A4rp7jZM'),
('Desa Tasik,Sungai Besi','No. 6 Jalan 30E/146, Desa Tasik, Sg Besi, 57000 Kuala Lumpur.', '57000', 'KUL', 'ChIJO2zKu_M1zDERskNJM6nxAvs'),
('Segambut','No 137 & 139, Jalan Segambut, 51200 Kuala Lumpur, Wilayah Persekutuan Kuala Lumpur.', '51200', 'KUL', 'ChIJnT0SDLVJzDERD2nAO_0rtEc'),
('Melaka','15, Jalan Melaka Raya 24, Tmn Melaka Raya, 75000 Melaka, Melaka.', '75000', 'MLK', 'ChIJQTKbDB3u0TERPFBa23btG2E'),
('Alor Gajah','KM 8-1,Jalan Perniagaan Jelatang 1,Pusat Perniagaan Jelatang,78000 Alor Gajah,Melaka.', '78000', 'MLK', 'ChIJ7wcrxwz90TEReAKAuFe5nVU'),
('Merlimau','JC 159 & 160, Jalan BMU 7, Bandar Baru Merlimau Utara, 77300 Merlimau, Melaka.', '77300', 'MLK', 'ChIJRaJefwHq0TER5-AU9ctC58Y'),
('Ayer Keroh','No.1, Jalan KPTU 1, Kawasan Perindustrian Tasik Utama, 75450 Ayer Keroh, Melaka.', '75450', 'MLK', 'ChIJ6zUBTTHl0TERTZnnjRzBadI'),
('Bahau','No. 5 Tingkat Bawah, Jln Meranti 4, Tmn Meranti, 72100 Bahau, N. Sembilan.', '72100', 'NSN', 'ChIJS1RTT59pzjERv8ewgQZiI3w'),
('Senawang','No. 20, Persiaran Andalas 2, Kawasan Industri Sinar Andalas, 70450 Seremban, Negeri Sembilan Darul Khusus.', '70450', 'NSN', 'ChIJy8fIq8jhzTERO9UXqrytU-Q'),
('Port Dickson','No.936, Ground Floor, Jalan D/S 3/1, Bandar Dataran Segar, 71010 Lukut, Port Dickson, Negeri Sembilan.', '71010', 'NSN', 'ChIJ5U0WkfTxzTER9RSu6LZwk0Y'),
('Nilai','No. 46, Jalan Tiara Sentral 2, Nilai Utama Enterprise Park, 71800 Nilai Utama, Negeri Sembilan.', '71800', 'NSN', 'ChIJw06LDtrFzTER578ZF_6Z-gg'),
('Seremban','No 45, Jln Kapitan Tam Yeong, 70100 Seremban, Negeri Sembilan.', '70100', 'NSN', 'ChIJdwHAgoTdzTERNPxQBOu6IBU'),
('Bukit Mertajam','No. 7, Lorong Industri Impian 1, Taman Industri Impian, 14000 Bukit Mertajam, Penang.', '14000', 'PNG', 'ChIJJQ7JKS7ISjARZylgYPVNI3c'),
('Butterworth','No 7, Persiaran Kerapu, Off Jalan Permatang Pauh, 13400 Butterworth, Penang.', '13400', 'PNG', 'ChIJP2hWmrXFSjARN2WP2-SM3-0'),
('Bayan Baru','No. 3, Jalan Sungai Tiram 7, Bayan Lepas 11900 Pulau Pinang.', '11900', 'PNG', 'ChIJX-h3T0DASjAR2635PmpV6xY'),
('Penang','No. 320, Jln Dato Keramat, 10150 Penang, Penang.', '10150', 'PNG', 'ChIJewaR3rjDSjARGTTbVUzJYmY'),
('Ayer Itam','No.30, Pine Valley Business Centre, Lebuh Rambai 11, Paya Terubong, 11060 Ayer Itam, Pulau Pinang.', '11060', 'PNG', 'ChIJI92qJr7BSjAR4Bg03BRwgy8'),
('Bentong','No. 46, Jln Loke Yew, Bentong 28700, Pahang.', '28700', 'PHG', 'ChIJ3YBQFWoFzDERU55lKtRj0zs'),
('Pekan','No. 15, Tingkat Bawah Pusat Perdagangan,Lorong Perdagangan 2,Jalan Engku Muda Mansoor, 26600 Pekan, Pahang.', '26600', 'PHG', 'ChIJrWv_w3tQzzERGjGx8NOFSfY'),
('Jerantut','No. 8266, Ground Floor, Tmn Sri Tahan, Jln Kuantan, 27000 Jerantut, Pahang.', '27000', 'PHG', 'ChIJq6qqeqdByTERjh7msswHGcY'),
('Kuantan','Lot 65459, Jln Industri Semambu 2, Kawasan Perindustrian Semambu, 25300 Kuantan, Pahang.', '25300', 'PHG', 'ChIJY1momxi7yDERZG-qA8WLuks'),
('Mentakab','No. 19 A & B, Batu 3 Jalan Mentakab, 28000 Temerloh, Pahang.', '28000', 'PHG', 'ChIJQ3XLB5W4zjERfvPZj9DlNbQ'),
('Ipoh','Lot 11, Medan Tasek, Tasek Industrial Estate, 31400 Ipoh, Perak.', '31400', 'PRK', 'ChIJexR2dy6TyjERVqDwNY8buBo'),
('Parit Buntar','No. 1, Jalan Pekaka 5, Taman Pekaka, 14300 Nibong Tebal, Perak.', '14300', 'PRK', 'ChIJ7ciSyEquSjARqdvRktxutKI'),
('Sitiawan','12, Ground Floor, Wisma Tiang Siang, Jln Dato Ahmad Yunus, 32000 Sitiawan, Perak.', '32000', 'PRK', 'ChIJh8qMNT0syzERXl6vaoUnORg'),
('Teluk Intan','No. 21, Lorong Perwira M1/38, Taman Nenas, 36000 Teluk Intan, Perak.', '36000', 'PRK', 'ChIJHzbl_CIVyzERU9YrGDmIufs'),
('Taiping','Tingkat Bawah No 47 & 49, Jalan Persiaran TBC, Taiping Business Centre, 34000 Taiping, Perak.', '34000', 'PRK', 'ChIJo0mxeWCuyjERdMpHeX_lPts'),
('Seri Iskandar','No.219 & 220, Persiaran SIBC 8, Bandar Seri Iskandar, 32610 Seri Iskandar, Perak Darul Ridzuan.', '32610', 'PRK', 'ChIJe7PYCM3fyjER9HsQ3kFRrzg'),
('Kampar','N0 1G & 3G, Laluan Batu Sinar 2, Kampar Sentral, 31900 Kampar, Perak.', '31900', 'PRK', 'ChIJaZJ0ASbjyjERgAk94P39I-8'),
('Perlis','No.28 & 30, Tingkat Bawah, Jalan Satu, Taman Jejawi Permai, 02600 Arau, Perlis.', '02600', 'PLS', 'ChIJWUY79LCZTDARScpgq2WAdEw'),
('Banting','No 171, Jalan Sultan Abdul Samad, 42700 Banting, Selangor.', '42700', 'SGR', 'ChIJOe0N6I6kzTERapCjCVShm6M'),
('Bangi','No 22,Jalan P/20, Taman Industri Selaman,Seksyen 10, 43650 Bandar Baru Bangi, Selangor', '43650', 'SGR', 'ChIJ7ZqvbEzKzTER-r67V-ufxtg'),
('Damansara Perdana','40 - 1 & 42 - 1,Jalan PJU 8/5B, Bandar Damansara Perdana, 47820 Petaling Jaya, Selangor.', '47820', 'SGR', 'ChIJJWS8_jBPzDERDpKIJt1_unU'),
('Kajang','5 Jln KP 1/4, Kajang Prima Off Jln Semenyih, 43000 Kajang, Selangor.', '43000', 'SGR', 'ChIJ25D8pWjMzTERW0ktPMT7flQ'),
('Klang','No.1, Jalan Sungai Batu 11/KU6, Kawasan Perindustrian Sungai Puloh, 42100 Klang, Selangor.', '42100', 'SGR', 'ChIJJ5HkxENUzDERNEKapm5YZ6U'),
('Batu Caves','16 Jalan SBC 8,Taman Sri Batu Caves Batu Caves, 68100 Selangor', '68100', 'SGR', 'ChIJdSyX2ghHzDERcqAzfHnZWOo'),
('Puchong','No.2, Jalan TPP1/11,Taman Industri Puchong, 47100 Puchong, Selangor.', '47100', 'SGR', 'ChIJNWxC8VmzzTERVQYzQ66uwCM'),
('Rawang','No. 21 & 23, Jalan Rawang Millenium, Pusat Perniagaan Millenium, 48000 Rawang, Selangor.', '48000', 'SGR', 'ChIJq0LcylNCzDERt1OCB_IRpso'),
('Subang Jaya','No 21, Jalan PJS 11/18, Bandar Sunway, 46150 Petaling Jaya, Selangor.', '46150', 'SGR', 'ChIJU4H4MIlMzDERXq12wWl4X8A'),
('Serdang','Lot 26, Kawasan Perindustrian Seri Kembangan, 43300 Seri Kembangan, Selangor.', '43300', 'SGR', 'ChIJS4AzK1-1zTERXStjFmuTtn8'),
('Sungai Buloh','Lot 508, Jalan TUDM, Kampung Baru Subang, Section U6, 40150 Shah Alam, Selangor.', '40150', 'SGR', 'ChIJIeom6DpOzDERFh89Ox4KCig'),
('Shah Alam','Lot 4,Jalan Bawang Putih 24/34, Seksyen 24, 40300 Shah Alam, Selangor.', '40300', 'SGR', 'ChIJq6qqaqxSzDERdPvFz1b_6MU'),
('Kuala Selangor','No.9 & 13. Jln Raja Lumu, 45000 Kuala Selangor, Selangor.', '45000', 'SGR', 'ChIJ06pn_1jzzDER1IHsKpVZE3Y'),
('KLIA','C-14, Block C MasCargo Complex, KLIA 64000 Sepang, Selangor.', '64000', 'SGR', 'ChIJ97y8-YO_zTEROV1imCMeOwI'),
('Bukit Beruntung','No.49G, Tingkat Bawah, Jalan Adenium 2G/5, Pusat Perniagaan Adenium, Bandar Bukit Beruntung, 48300 Rawang, Selangor.', '48300', 'SGR', 'ChIJoxijCENpzDERzC5DDRq2J8E'),
('Ampang','No 37, Jalan Mewah 3/2, Hata Industrial Centre, Pandan Mewah, 68000 Ampang, Selangor.', '68000', 'SGR', 'ChIJGfn76JM2zDERXFUcCyynWGQ'),
('Kota Kemuning','No 14 & No 16, Jalan Tamborin 33/23, Seksyen 33 Shah Alam Technology Park, 40400 Shah Alam, Selangor.', '40400', 'SGR', 'ChIJlUH8O7myzTER8Sqg4Vqh90M'),
('Bukit Rahman Putra','3, Jalan SB Jaya 2, Taman Industri Jaya, 47000 Sungai Buloh, Selangor', '47000', 'SGR', 'ChIJKaCE9exFzDERU823nJpuRVc'),
('Tun Hussein Onn','No.10, Jalan KPB 16, Kawasan Perindustrian Balakong, 43200 Balakong Selangor.', '43200', 'SGR', 'ChIJhYcYCCo1zDERlVz2lJqlhI0'),
('Klang','No.18, Ground Floor, Jalan Nanas, 41400 Klang, Selangor.', '41400', 'SGR', 'ChIJmbD0mERTzDERsxP-8Xaici4'),
('Port Klang','No.16, PT14343, Jalan Pandamaran Jaya,Kg Idaman, 42000,Pelabuhan Klang. Selangor.', '42000', 'SGR', 'ChIJ7-CcyburzTERNrX4qvVYLHI'),
('Port Klang','154, Persiaran Pegaga, Tman Bayu Perdana,41200 Klang, Selangor.', '41200', 'SGR', 'ChIJKUw7116rzTERAYm1RVd4OKk'),
('K. Terengganu','Lot PT 2876 and 2877, Tingkat Bawah,Jalan Pasir Panjang,Bukit Besar, 21100 K.Terengganu, Terengganu.', '21100', 'TRG', 'ChIJpTX2KkO-tzERy-b6KtMNngw'),
('Ajil','No. 39G, Lorong Kirana 1, Taman Kirana, 21700 Kuala Berang, Terengganu.', '21700', 'TRG', 'ChIJl_hBqSLbtzERZuLxDngG0Ls'),
('Kemaman','K127 Ground Floor, Jalan Abdul Rahman, 24000 Kemaman, Terengganu.', '24000', 'TRG', 'ChIJV7Vdhu6GyDER-gc44QAz4WM'),
('Paka','PT 20639, Jalan Besar, Kampung Tebing Tembah, 23100 Paka, Terengganu.', '23100', 'TRG', 'ChIJqzLb-kMMyDERrqh91vn3s-k');