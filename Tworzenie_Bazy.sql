USE [master]
GO
CREATE DATABASE [Projekt]
USE [Projekt]
GO
CREATE TABLE [dbo].[Pojazdy](
	[ID_Samochodu] [int] IDENTITY(1,1) NOT NULL,
	[Vin] [varchar](17) NOT NULL,
	[Rejestracja] [varchar](7) NOT NULL,
	[Marka] [varchar](50) NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Rok_Produkcji] [datetime] NOT NULL,
	[Wersja_Silnika] [varchar](10) NOT NULL,
	[Moc] [int] NOT NULL,
	[Wersja_Wyposazenia] [varchar](50) NOT NULL,
	[Numer_Transpondera_GPS] [varchar](30) NOT NULL,
	[Rodzaj_Nadwozia] [varchar](15) NOT NULL,
	[Stawka] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Samochodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Numer_Transpondera_GPS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Rejestracja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Vin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pojazdy]  WITH CHECK ADD  CONSTRAINT [Błędny_VIN] CHECK  ((len([Vin])>=(17)))
GO

ALTER TABLE [dbo].[Pojazdy] CHECK CONSTRAINT [Błędny_VIN]
GO

ALTER TABLE [dbo].[Pojazdy]  WITH CHECK ADD  CONSTRAINT [Check_Rok_Produkcji] CHECK  (([Rok_Produkcji]>=(datepart(year,getdate())-(5))))
GO

ALTER TABLE [dbo].[Pojazdy] CHECK CONSTRAINT [Check_Rok_Produkcji]

CREATE TABLE [dbo].[Pracownicy](
	[KodPracownika] [int] IDENTITY(1,1) NOT NULL,
	[Nazwisko] [varchar](50) NOT NULL,
	[Imie] [varchar](50) NOT NULL,
	[Ulica] [varchar](50) NOT NULL,
	[Nr_mieszkania] [int] NOT NULL,
	[Miejscowość] [varchar](50) NOT NULL,
	[Kod_Pocztowy] [varchar](5) NOT NULL,
	[Rok_Rozpoczecia_Pracy] [datetime] NOT NULL,
	[Stanowisko] [varchar](50) NOT NULL,
	[Pensja] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KodPracownika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pracownicy]  WITH CHECK ADD  CONSTRAINT [Błędny_rok_zatrudnienia] CHECK  (([Rok_Rozpoczecia_Pracy]>=(((2020)-(1))-(1))))
GO

ALTER TABLE [dbo].[Pracownicy] CHECK CONSTRAINT [Błędny_rok_zatrudnienia]
GO
CREATE TABLE [dbo].[Klienci](
	[IDKlienta] [int] IDENTITY(1,1) NOT NULL,
	[Nazwisko] [varchar](50) NOT NULL,
	[Imie] [varchar](50) NOT NULL,
	[Pesel] [varchar](11) NOT NULL,
	[Wiek] [int] NOT NULL,
	[Nr_PrawaJazdy] [varchar](50) NOT NULL,
	[Ulica] [varchar](50) NOT NULL,
	[Nr_mieszkania] [int] NOT NULL,
	[Kod_Pocztowy] [varchar](6) NOT NULL,
	[Telefon] [varchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDKlienta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Klienci]  WITH CHECK ADD  CONSTRAINT [Błędny_Pesel] CHECK  ((len([Pesel])>=(11)))
GO

ALTER TABLE [dbo].[Klienci] CHECK CONSTRAINT [Błędny_Pesel]
GO

ALTER TABLE [dbo].[Klienci]  WITH CHECK ADD  CONSTRAINT [Wiek] CHECK  (([Wiek]>=(21)))
GO

ALTER TABLE [dbo].[Klienci] CHECK CONSTRAINT [Wiek]
GO
CREATE TABLE [dbo].[Wypozyczenia](
	[IDWypozyczenia] [int] IDENTITY(1,1) NOT NULL,
	[IDKlienta] [int] NOT NULL,
	[ID_Samochodu] [int] NOT NULL,
	[KodPracownika] [int] NOT NULL,
	[Data_Wypozyczenia] [date] NOT NULL,
	[Data_Zwrotu] [date] NOT NULL,
	[Długość_wypozyczenia]  AS (datediff(day,[Data_Wypozyczenia],[Data_Zwrotu])),
PRIMARY KEY CLUSTERED 
(
	[IDWypozyczenia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Uniklane_Wypożyczenie] UNIQUE NONCLUSTERED 
(
	[ID_Samochodu] ASC,
	[Data_Wypozyczenia] ASC,
	[Data_Zwrotu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Wypozyczenia]  WITH CHECK ADD FOREIGN KEY([ID_Samochodu])
REFERENCES [dbo].[Pojazdy] ([ID_Samochodu])
GO

ALTER TABLE [dbo].[Wypozyczenia]  WITH CHECK ADD FOREIGN KEY([IDKlienta])
REFERENCES [dbo].[Klienci] ([IDKlienta])
GO

ALTER TABLE [dbo].[Wypozyczenia]  WITH CHECK ADD FOREIGN KEY([KodPracownika])
REFERENCES [dbo].[Pracownicy] ([KodPracownika])
GO

ALTER TABLE [dbo].[Wypozyczenia]  WITH CHECK ADD  CONSTRAINT [Błędna_Data] CHECK  (([Data_Wypozyczenia]<[Data_Zwrotu]))
GO

ALTER TABLE [dbo].[Wypozyczenia] CHECK CONSTRAINT [Błędna_Data]

-- Dodatkowe dane dla tabeli Pojazdy
INSERT INTO [dbo].[Pojazdy] 
  (Vin, Rejestracja, Marka, Model, Rok_Produkcji, Wersja_Silnika, Moc, Wersja_Wyposazenia, Numer_Transpondera_GPS, Rodzaj_Nadwozia, Stawka) 
VALUES
  ('1HGCM82633A123458', 'DEF1234', 'Ford', 'Focus', '2019-01-01', '1.6', 125, 'Standard', '123456789012347', 'Hatchback', 300.00),
  ('1HGCM82633A123459', 'GHI1234', 'BMW', '320', '2021-01-01', '2.0', 184, 'Luxury', '123456789012348', 'Sedan', 600.00),
  ('1HGCM82633A123460', 'JKL1234', 'Audi', 'A4', '2022-01-01', '2.0', 190, 'Luxury', '123456789012349', 'Sedan', 600.00),
  ('1HGCM82633A123461', 'MNO1234', 'Volkswagen', 'Golf', '2020-01-01', '1.5', 130, 'Standard', '123456789012350', 'Hatchback', 350.00);

-- Dodatkowe dane dla tabeli Pracownicy
INSERT INTO [dbo].[Pracownicy] 
  (Nazwisko, Imie, Ulica, Nr_mieszkania, Miejscowość, Kod_Pocztowy, Rok_Rozpoczecia_Pracy, Stanowisko, Pensja) 
VALUES
  ('Zieliński', 'Tomasz', 'Zielona', 3, 'Poznań', '60001', '2021-06-01', 'Sprzedawca', 5200.00),
  ('Woźniak', 'Mariusz', 'Cicha', 4, 'Wrocław', '50001', '2020-05-01', 'Sprzedawca', 5300.00),
  ('Kowalczyk', 'Robert', 'Główna', 5, 'Szczecin', '70001', '2020-07-01', 'Sprzedawca', 5500.00),
  ('Kamiński', 'Rafał', 'Szeroka', 6, 'Łódź', '90001', '2019-04-01', 'Manager', 8500.00);

-- Dodatkowe dane dla tabeli Klienci
INSERT INTO [dbo].[Klienci] 
  (Nazwisko, Imie, Pesel, Wiek, Nr_PrawaJazdy, Ulica, Nr_mieszkania, Kod_Pocztowy, Telefon) 
VALUES
  ('Lewandowski', 'Andrzej', '87030312345', 36, 'DEF123456', 'Spokojna', 30, '00-002', '700800900'),
  ('Włodarczyk', 'Marek', '90040412345', 33, 'GHI123456', 'Równa', 40, '30-002', '800900100'),
  ('Baran', 'Łukasz', '93050512345', 30, 'JKL123456', 'Leśna', 50, '00-003', '900100200'),
  ('Sikora', 'Piotr', '96060612345', 27, 'MNO123456', 'Parkowa', 60, '30-003', '100200300');

-- Dodatkowe dane dla tabeli Wypozyczenia
INSERT INTO [dbo].[Wypozyczenia] 
  (IDKlienta, ID_Samochodu, KodPracownika, Data_Wypozyczenia, Data_Zwrotu) 
VALUES
  (3, 3, 3, '2023-03-01', '2023-03-07'),
  (4, 4, 4, '2023-04-01', '2023-04-07'),
  (5, 5, 5, '2023-05-01', '2023-05-07'),
  (6, 6, 6, '2023-06-01', '2023-06-07');
