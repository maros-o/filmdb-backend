CREATE TABLE countries 
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
)
GO
INSERT INTO countries (name)
VALUES ('USA')
GO
INSERT INTO countries (name)
VALUES ('Velká Británie')
GO
INSERT INTO countries (name)
VALUES ('Česko')
GO
INSERT INTO countries (name)
VALUES ('Nový Zéland')
GO
INSERT INTO countries (name)
VALUES ('Rakousko')
GO
INSERT INTO countries (name)
VALUES ('Kanada')
GO
INSERT INTO countries (name)
VALUES ('Francie')
GO

CREATE TABLE movies 
(
	id INT IDENTITY PRIMARY KEY,
	title VARCHAR(50) NOT NULL,
	slug VARCHAR(50) UNIQUE NOT NULL,
	description VARCHAR(1000) NOT NULL,
	length INT NOT NULL,
	release_year SMALLINT NOT NULL,
	country_id INT NOT NULL FOREIGN KEY REFERENCES countries (id),
	image_url VARCHAR(500) NOT NULL
)
GO
INSERT INTO movies (title, slug, description, length, release_year, country_id, image_url)
VALUES ('Terminátor', 'terminator1984', 'Terminátor je dnes již považován za naprostou legendu sci-fi žánru. Vypráví příběh o zabijáckém stroji podobném člověku, který je vyslán z roku 2029 do Los Angeles roku 1984. Jeho úkolem je zabít Sarah Connorovou dřív, než přivede na svět syna, který se má později stát vůdcem lidí ve válce proti strojům. Avšak lidé žijící v budoucnosti do současnosti také vyslali svého muže, který se bude snažit Sarah zachránit.',
107, 1984, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w140/files/images/film/posters/164/654/164654904_3bbdaf.jpg')
GO
INSERT INTO movies (title, slug, description, length, release_year, country_id, image_url)
VALUES ('Predátor', 'predator1987', 'Arnold Schwarzenegger má jako major Dutch v Predátorovi vcelku rutinní úkol, vysvobodit několik amerických vojáků ze zajetí partyzánů uprostřed džungle. Nakonec se ale musí utkat s daleko tajemnějším a nebezpečnějším nepřítelem. On i jeho muži čelí děsivému mimozemšťanovi, který postaví americké hrdiny poprvé v životě před opravdový strach.',
107, 1987, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w140/files/images/film/posters/160/570/160570338_5d8063.jpg')
GO
INSERT INTO movies (title, slug, description, length, release_year, country_id, image_url)
VALUES ('Terminátor 2: Den zúčtování', 'terminator2', 'V budoucnosti probíhá válka lidí se stroji, které převzaly vládu nad světem. Jedinou nadějí pro lidstvo je charismatický vůdce Hnutí odporu John Connor. Protože se ho stroje obávají, vysílají do minulosti nový prototyp kyborga, který ho má zničit jako malého chlapce. Vzápětí za ním Hnutí odporu vyšle starý model terminátora, přeprogramovaného tak, aby mladého Johna chránil.',
137, 1991, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w140/files/images/film/posters/162/030/162030421_a857c2.jpg')
GO
INSERT INTO movies (title, slug, description, length, release_year, country_id, image_url)
VALUES ('Vykoupení z věznice Shawshank', 'vykoupeni-z-veznice-shawshank', 'Mladý bankéř Andy Dufresne je v roce 1947 odsouzen za vraždu své ženy a jejího milence. Přesto, že tento čin popírá, čeká na něj dvojnásobný doživotní trest v obávané věznici Shawshank. Andy se snaží přizpůsobit vězeňskému životu a po krušných začátcích se sblíží s Redem, jenž si tu odpykává svůj doživotní trest už dvacet let. Sílu, jak přežít zdejší peklo, Andy nachází v tajném snu a skryté naději na svobodu...',
142, 1994, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w140/files/images/film/posters/162/505/162505167_735db9.jpg')
GO
INSERT INTO movies (title, slug, description, length, release_year, country_id, image_url)
VALUES ('Zelená míle', 'zelena-mile', 'Paul Edgecomb se vrací ve vzpomínkách do roku 1935, kdy byl zaměstnán v louisianské věznici jako hlavní dozorce. Tenkrát se tam setkal s výjimečným, byť duchem prostým mužem, který byl obdařen nejen velkým srdcem, ale také nadpozemskými schopnostmi. Byl to John Coffey, neprávem odsouzený na smrt za vraždu dvou malých holčiček. V té době trpěl Paul těžkým zánětem močového měchýře a také neměl šanci zbavit se sadistického, všemi nenáviděného dozorce Percyho. Jednoho dne chce s Paulem mluvit Coffey. Když se k němu přiblíží, chytí ho rukou v rozkroku, pak šokovaného Paula pustí a on uvidí, jak černoch vypustil z úst černý oblak, a současně si uvědomí, že jeho bolestivý zánět zmizel.',
188, 1999, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w140/files/images/film/posters/000/079/79050_b712c4.jpg')
GO
INSERT INTO movies (title, slug, description, length, release_year, country_id, image_url)
VALUES ('Forrest Gump', 'forrest-gump', 'Mladý muž jménem Forrest Gump sedí na zastávce autobusu a každému, kdo si přisedne, vypráví o svém životě. Poněkud jednoduchý chlapec se narodil v Alabamě, kde žil jen s matkou, která mu dala mnoho dobrých rad do života. Především tu, aby si nikdy nenechal od nikoho namluvit, že je jiný než ostatní. Dostala ho dokonce i do normální školy, přestože jí doporučovali zvláštní, vzhledem k jeho nízkému IQ. Forrest, terč zlomyslných vtípků a krutých žertů svých kamarádů, si tam najde přítelkyni na celý život: Jenny je půvabná blonďatá holčička, kterou zneužívá otec, a tak ji dají do výchovy babičce. Oba se stanou nerozlučnými přáteli. Jenny Forrestovi dá další cennou radu do života: když budeš mít problém, utíkej. A tak Forrest proutíká školou, pak i střední školou a nakonec vysokou, kde se osvědčí jako nejrychlejší hráč amerického fotbalu.',
142 , 1994, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w140/files/images/film/posters/158/988/158988468_acc7b5.jpg')
GO

CREATE TABLE person 
(
	id INT IDENTITY PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	slug VARCHAR(50) UNIQUE NOT NULL,
	description VARCHAR(1000) NOT NULL,
	birth_year SMALLINT NOT NULL,
	country_id INT NOT NULL FOREIGN KEY REFERENCES countries (id),
	image_url VARCHAR(500) NOT NULL
)
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Arnold Schwarzenegger', 'arnold-schwarzenegger', 'Akční hrdina a nejlépe placený herec v Hollywoodu Arnold Schwarzenegger se narodil 30. července 1947 v Thalu v Rakousku v chudých poměrech. Se svou rodinou žil ve tři sta let starém činžáku, kde neměli elektřinu, ústřední topení ani vodovod. Arnold tak se svým bratrem museli vodu nosit z fontány vzdálené 150 m. Již od mládí se věnoval po vzoru svého otce sportu nejdříve fotbalu, pak atletice a nakonec se rozhodl pro kulturistiku.',
1947, (SELECT id FROM countries WHERE name = 'Rakousko'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/000/267/267359_928644.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Michael Biehn', 'michael-biehn', 'Michael Connell Biehn, sympatický chlapec z Alabamy, nedokončil štúdium herectva a snažil sa to dohnať aspoň hereckými kurzami v L. A. Syn právnika a zdravotnej sestry. Privyrábal si ako čašník, predavač, stavbár. Pred oltárom sľúbil vernosť ako prvej Carlene Olsonovej, potom Gine Marshovej. Slávu aj prekliatie zároveň mu priniesol jediný tvorca - James Cameron. Urobil z neho akčnú hviezdu, s ktorou menej talentovaní filmári nevedeli pracovať a on sa utopil v akčných béčkach. Zo začiatku hrával v reklamách, postupne sa prebojoval do seriálov (LOGAN´S RUN, HILL STREET BLUES).',
1956, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/162/753/162753573_73eb9b.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('James Cameron', 'james-cameron', 'Nikdy neštudoval filmárčinu. Začínal ako chudobný vodič kamiónu. Je piatykrát ženatý. Keď treba, s hercami zaobchádza ako s dobytkom. Pri strihaní Titanicu si na monitor prilepil žiletku s odkazom "Použiť iba v prípade, že film nebude fungovať." Titanic nakoniec zafungoval, získal 11 Oscarov a James zaň dostal odmenu $115 milónov USD.',
1954, (SELECT id FROM countries WHERE name = 'Kanada'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/000/269/269558_171cd5.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('John McTiernan', 'john-mctiernan', 'John McTiernan je jeden z nejlepších a technicky nejkouzelnějších režisérů, kteří dokážou opakovaně rozdýchat i ten nejhloupější scénář, moderním umístěním a nadčasovým humorem. Proč se dítě ze severního New Yorku stalo jedím z nejžádanějších režisérů v Hollywoodu? "Chtěl jsem být zprvu divadelním režisérem, ale neměl jsem svěřenecký fond", zavtipkoval jednou.',
1951, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/000/269/269682_e1b778.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Linda Hamilton', 'linda-hamilton', 'Jej najslávnejším filmom pravdepodobne zostane TERMINÁTOR, kde stelesnila čašníčku Sarah Connorovú (režisér James Cameron sa pri písaní scenára inšpiroval svojou prvou – z mnohých – manželkou, čašníčkou Sarah Williamsovou), budúcu matku Spasiteľa ľudstva vo vojne proti strojom. V tom istom roku si s Petrom Hortonom zahrala v adaptácii poviedky Stephena Kinga KUKURIČNÉ DETI. Rozhádaní manželia idú naprieč Štátmi za novým, snáď lepším životom, kdesi v Nebraske sa zastavia v ľudoprázdnom mestečku Gatlin a čaká ich nemilé prekvapenie – vďaka bytosti z kukuričných polí, siahajúcich kam len oko dovidí, miestne deti zabili každého, kto prekročil prah dospelosti. Film síce disponoval diametrálne odlišným koncom ako poviedka, ale fanúšikovia kingovčín sa zhodujú, že je tým lepším, čo Hollywood natočil podľa jeho kníh.',
1956, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/000/267/267388_016456.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Tim Robbins', 'tim-robbins', 'Timothy Francis Robbins sa síce narodil v slnečnej Kalifornii, ale iba málokedy hráva vo vyložených komédiách. Pristanú mu záporné úlohy alebo smutné kladné, ktoré sa niečím v živote previnili, ale zvyknú si to dramatizovať oveľa viac, ako je možno potrebné. Veď kto by zabudol na mladučkého bankového úradníka Andyho Dufresnea z adaptácie novely Stephena Kinga VYKÚPENIE Z VÄZNICE SHAWSHANK? „Nestlačil som spúšť, ale svojim spôsobom som ju naozaj zabil. Odohnal som ju.“ Práve sympatický Andy, ktorý sa správa, ako keby vo väzení nebol doživotne, ale iba na návšteve, tomuto vysokánskemu hercovi (1.96 metra) pravdepodobne prepožičal závoj nesmrteľnosti. Zveličene by sa dalo povedať, že Robbins môže nakrúcať akékoľvek hlúposti a tolerantnosť divákov, milujúcich Darabontov film, bude viac-menej nekonečná.',
1958, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/163/921/163921450_a7778f.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Morgan Freeman', 'morgan-freeman', 'Vysoký, postarší, černý herec s klidným výrazem a vyzrálým hlasem rozhodně nepatří k těm, kteří by zásobovali média svými výstřednostmi a aférami jakéhokoli druhu. Vyhledávaným hercem se stal až po čtyřicítce, skutečné slávy dosáhl po padesátce, takže téměř půlstoletí jeho života zůstává skryto. Vyjadřuje se jedině k filmovým problémům a dnes už si nikdo ani nedovoluje pokládat mu jiné otázky.',
1937, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/164/428/164428580_f35cb3.png')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Frank Darabont', 'frank-darabont', 'Rodený Francúz, režisér-scenárista-producent-šéf výroby Frank Darabont, je povestný tým, že kamarátom (alebo za dobrý plat) rád vypomáha s neoficiálnymi prácami na scenároch. Prsty má v Mannovom COLLATERAL, ale záchranné práce robil aj na Branaghovom FRANKENSTEINOVI, MASKE s Jimom Carreym a Spielbergovom VOJAKOVI RYANOVI. Ako scenárista je podpísaný pod NOČNOU MOROU 3 Chucka Russella, ktorému napísal aj sci-fi horor THE BLOB (1988). Písal MUCHU 2, televízne PRÍBEHY Z HROBKY, televíznu show DOBRODRUŽSTVÁ MLADÉHO INDIANA JONESA. Ale nie vždy to ide, napokon ako scenárista zlyhal na prácach na Indiana Jones 4 a Mission: Impossible 3.',
1959, (SELECT id FROM countries WHERE name = 'Francie'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/166/891/166891440_27670a.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Tom Hanks', 'tom-hanks', 'Jeho rodiče se rozvedli, když mu bylo pouhých pět let. Na střední škole se věnoval sportu a chtěl se stát kosmonautem. Nakonec ale objevil herectví. Své komediální nadání zužitkoval už na prknech školního divadla, kde také začal sbírat svá první ocenění. Jeho kroky posléze vedly přes Chabotskou univerzitu na Kalifornskou státní univerzitu v Scramentu, kde potkal svou první manželku Samanthu Lewes, s níž má syna Colina (který se také stal hercem) a dceru Elizabeth. Při natáčení filmu VOLUNTEERS se seznámil s Ritou Wilson, která se nakonec v roce 1988 stala jeho druhou ženou. Mají spolu dvě děti.',
1956, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/160/071/160071789_ea6bde.jpg')
GO
INSERT INTO person (name, slug, description, birth_year, country_id, image_url)
VALUES ('Robert Zemeckis', 'robert-zemeckis', 'Okuliarnatý vizionár, producent, vedúci výroby, scenárista, režisér, tvorca amerických filmov, pokladaných za „veľké“. Krátkometrážne nakrúcal už na strednej. Študoval na Juhokalifornskej univerzite (prestúpil na ňu z Northern Illinois University). Dnes býva pokladaný za „žiaka“ Stevena Spielberg, podobne, ako napr. Joe Dante („Gemlins“) alebo Tobe Hooper („Poltergeist“). Nejedná sa o to, že by Spielberg vyučoval réžiu na nejakej univerzite; pod slovným spojením „žiak - učiteľ“ sa má na mysli to, že Spielberg, pamätajúci na trpkú pachuť zo svojich začiatkov (kedy mu mocní producenti nedôverovali a hádzali polená pod nohy), si často bral pod ochranné krídla svojich menej slávnych ale dokonca ešte len začínajúcich rovesníkov (Zemeckis je od neho mladší o päť rokov) a z pozície producenta / šéfa výroby im poskytoval dostatok priestoru na realizovanie ich vlastných nápadov.',
1951, (SELECT id FROM countries WHERE name = 'USA'), 'https://image.pmgstatic.com/cache/resized/w100h132crop/files/images/creator/photos/000/269/269775_75169b.jpg')
GO

CREATE TABLE movie_actor 
(
	person_id INT NOT NULL FOREIGN KEY REFERENCES person (id),
	movie_id INT NOT NULL FOREIGN KEY REFERENCES movies (id),
	PRIMARY KEY (person_id, movie_id)
)
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'arnold-schwarzenegger'), (SELECT id FROM movies WHERE slug = 'terminator1984'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'arnold-schwarzenegger'), (SELECT id FROM movies WHERE slug = 'predator1987'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'michael-biehn'), (SELECT id FROM movies WHERE slug = 'terminator1984'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'arnold-schwarzenegger'), (SELECT id FROM movies WHERE slug = 'terminator2'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'linda-hamilton'), (SELECT id FROM movies WHERE slug = 'terminator1984'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'linda-hamilton'), (SELECT id FROM movies WHERE slug = 'terminator2'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'tim-robbins'), (SELECT id FROM movies WHERE slug = 'vykoupeni-z-veznice-shawshank'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'morgan-freeman'), (SELECT id FROM movies WHERE slug = 'vykoupeni-z-veznice-shawshank'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'tom-hanks'), (SELECT id FROM movies WHERE slug = 'zelena-mile'))
GO
INSERT INTO movie_actor (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'tom-hanks'), (SELECT id FROM movies WHERE slug = 'forrest-gump'))
GO

CREATE TABLE movie_director 
(
	person_id INT NOT NULL FOREIGN KEY REFERENCES person (id),
	movie_id INT NOT NULL FOREIGN KEY REFERENCES movies (id),
	PRIMARY KEY (person_id, movie_id)
)
GO
INSERT INTO movie_director (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'james-cameron'), (SELECT id FROM movies WHERE slug = 'terminator1984'))
GO
INSERT INTO movie_director (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'john-mctiernan'), (SELECT id FROM movies WHERE slug = 'predator1987'))
GO
INSERT INTO movie_director (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'james-cameron'), (SELECT id FROM movies WHERE slug = 'terminator2'))
GO
INSERT INTO movie_director (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'frank-darabont'), (SELECT id FROM movies WHERE slug = 'vykoupeni-z-veznice-shawshank'))
GO
INSERT INTO movie_director (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'frank-darabont'), (SELECT id FROM movies WHERE slug = 'zelena-mile'))
GO
INSERT INTO movie_director (person_id, movie_id)
VALUES ((SELECT id FROM person WHERE slug = 'robert-zemeckis'), (SELECT id FROM movies WHERE slug = 'forrest-gump'))
GO

CREATE TABLE users
(
	id INT IDENTITY PRIMARY KEY,
	username VARCHAR(20) NOT NULL,
	email VARCHAR(50) NOT NULL,
	password VARCHAR(50) NOT NULL
)
GO
INSERT INTO users (username, email, password)
VALUES ('tester', 'test@seznam.cz', 'test')
GO

CREATE TABLE movie_review
(
	users_id INT NOT NULL FOREIGN KEY REFERENCES users (id),
	movie_id INT NOT NULL FOREIGN KEY REFERENCES movies (id),
	comment VARCHAR(500) NULL,
	rating TINYINT NOT NULL CHECK (rating BETWEEN 0 AND 10),
	create_date DATETIME NOT NULL CONSTRAINT DF_rental_create_date DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (users_id, movie_id)
)
GO
INSERT INTO movie_review (users_id, movie_id, comment, rating)
VALUES (1,3, 'nic moc film', 5)
GO
INSERT INTO movie_review (users_id, movie_id, comment, rating)
VALUES (2,3, 'luxusni film', 9)
GO
INSERT INTO movie_review (users_id, movie_id, comment, rating)
VALUES (3,3, 'da se', 8)
