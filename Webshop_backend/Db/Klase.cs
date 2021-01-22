using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop_backend.Db
{
	public class Mjesto
	{
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string PostanskiBroj { get; set; }
	}
	public class Kategorija
	{
		public int IdKategorija { get; set; }
		public string Naziv { get; set; }
	}
	public class Klijent
	{
		public int IdKlijent { get; set; }
		public int? IdOsoba { get; set; }
		public int? StoreID { get; set; }
		public string BrojKlijenta { get; set; }
	}
	public class ModelProizvoda
	{
		public int IdModel { get; set; }
		public string Naziv { get; set; }
		public String OpisUKatalogu { get; set; }
		public String Upute { get; set; }
	}
	public class Narudzba
	{
		public int IdNarudzba { get; set; }
		public DateTime DatumNarudzbe { get; set; }
		public DateTime? DatumIsteka { get; set; }
		public DateTime? DatumSlanja { get; set; }
		public String Status { get; set; }
		public Boolean? Online { get; set; }
		public string Broj { get; set; }
		public string BrojRacuna { get; set; }
		public string BrojKlijenta { get; set; }
		public int? IdKlijent { get; set; }
		public int? IdProdavac { get; set; }
		public int? AdresaRacuna { get; set; }
		public int? AdresaSlanja { get; set; }
		public int? ShipMethodID { get; set; }
		public int? BrojKartice { get; set; }
		public string Kod { get; set; }
		public decimal? Poštarina { get; set; }
		public string Opaska { get; set; }
		public DateTime? VrijemeKreiranja { get; set; }
		public DateTime? VrijemePromjene { get; set; }
	}
	public class NarudzbaDetalj
	{
		public int IdNarudzba { get; set; }
		public int IdNarudzbaDetalj { get; set; }
		public short Kolicina { get; set; }
		public int IdProizvod { get; set; }
		public decimal JedinicnaCijena { get; set; }
		public decimal Rabat { get; set; }
	}
	public class Odjel
	{
		public short IdOdjel { get; set; }
		public string Naziv { get; set; }
		public string Grupa { get; set; }
	}
	public class Osoba
	{
		public int IdOsoba { get; set; }
		public string Titula { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Sufix { get; set; }
		public int? Email { get; set; }
		public String Opis { get; set; }
		public int? IdMjesto { get; set; }
	}
	public class Telefon
	{
		public int Id { get; set; }
		public int? IdOsoba { get; set; }
		public string Broj { get; set; }
		public int? IdTipTelefona { get; set; }
	}
	public class Podkategorija
	{
		public int IdPodkategorija { get; set; }
		public int IdKategorija { get; set; }
		public string Naziv { get; set; }
	}
	public class ExchangeRate
	{
		public int Id { get; set; }
		public int? Currency { get; set; }
		public int? Month { get; set; }
		public int? Year { get; set; }
		public decimal? Amount { get; set; }
	}
	public class Proizvod
	{
		public int IdProizvod { get; set; }
		public string Naziv { get; set; }
		public string Broj { get; set; }
		public Boolean? ProizvodnaOznaka { get; set; }
		public Boolean? KonacnaOznaka { get; set; }
		public string Boja { get; set; }
		public short? MinimumStanjeSkladiste { get; set; }
		public short? TockaNarudzbe { get; set; }
		public decimal? TrosakIzrade { get; set; }
		public decimal? ProdajnaCijena { get; set; }
		public string Velicina { get; set; }
		public string KodVelicine { get; set; }
		public string KodTezine { get; set; }
		public decimal? Tezina { get; set; }
		public int? DanaZaIzradu { get; set; }
		public string LinijaProizvoda { get; set; }
		public string Klasa { get; set; }
		public string Stil { get; set; }
		public int? IdPodKategorija { get; set; }
		public int? IdModel { get; set; }
		public DateTime? PocetakProdaje { get; set; }
		public DateTime? KrajProdaje { get; set; }
		public DateTime? DatumPovlacenja { get; set; }
		public int? IdKategorija { get; set; }
	}
	public class Ulaz
	{
		public int IdUlaz { get; set; }
		public String Broj { get; set; }
		public String Status { get; set; }
		public int IdZaposlenik { get; set; }
		public int IdProizvodac { get; set; }
		public int IdMetoda { get; set; }
		public DateTime DatumNarudzbe { get; set; }
		public DateTime? DatumSlanja { get; set; }
		public decimal Postarina { get; set; }
	}
	public class UlazDetalj
	{
		public int IdUlaz { get; set; }
		public int IdUlazDetalj { get; set; }
		public DateTime DatumDospijeca { get; set; }
		public short Kolicina { get; set; }
		public int IdProizvod { get; set; }
		public decimal JedinicnaCijena { get; set; }
	}
	public class Zaposlenik
	{
		public int IdZaposlenik { get; set; }
		public string SluzbeniBroj { get; set; }
		public string Login { get; set; }
		public short? Nivo { get; set; }
		public string Titula { get; set; }
		public String DatumRodenja { get; set; }
		public string BracniStatus { get; set; }
		public string Spol { get; set; }
		public String DatumZaposlenja { get; set; }
		public short SatiGodisnji { get; set; }
		public short SatiBolovanja { get; set; }
		public decimal? Placa { get; set; }
		public string Odjel { get; set; }
	}
	public class ZaposlenikOdjel
	{
		public int IdZaposlenik { get; set; }
		public short IdOdjel { get; set; }
		public String PocetakRada { get; set; }
		public String KrajRada { get; set; }
	}

}
