CREATE TABLE category (
  kategoria_id INTEGER NOT NULL IDENTITY(1,1),
  Kategoria VARCHAR(45) NOT NULL,
  Opis VARCHAR(max) NOT NULL,
  PRIMARY KEY(kategoria_id)
);

CREATE TABLE role (
  role_id INTEGER NOT NULL IDENTITY(1,1),
  Rola VARCHAR(45) NOT NULL,
  opis VARCHAR(max),
  PRIMARY KEY(role_id)
);

CREATE TABLE users (
  user_id INTEGER NOT NULL IDENTITY(1,1),
  role_id INTEGER NOT NULL DEFAULT 2 FOREIGN KEY REFERENCES role(role_id) ON DELETE CASCADE,
  nick VARCHAR(45) UNIQUE NOT NULL,
  haslo CHAR(20) NOT NULL,
  data_rej DATE DEFAULT GETDATE(),
  PRIMARY KEY(user_id)
);

CREATE TABLE posts (
  post_id INTEGER NOT NULL IDENTITY(1,1),
  kategoria_id INTEGER NOT NULL FOREIGN KEY REFERENCES category(kategoria_id) ON DELETE CASCADE,
  user_id INTEGER NOT NULL FOREIGN KEY REFERENCES users(user_id) ON DELETE CASCADE,
  Temat CHAR(30) NOT NULL,
  Gra CHAR(30) NOT NULL,
  Tresc TEXT NOT NULL,
  data_dodania DATETIME2(0) DEFAULT GETDATE(),
  PRIMARY KEY(post_id)
);


CREATE TABLE comments (
  id_comment INTEGER NOT NULL IDENTITY(1,1),
  post_id INTEGER NOT NULL FOREIGN KEY REFERENCES posts(post_id) ON DELETE CASCADE,
  user_id INTEGER NOT NULL FOREIGN KEY REFERENCES users(user_id),
  Tresc TEXT NOT NULL,
  PRIMARY KEY(id_comment)
);


INSERT INTO role (Rola,opis) VALUES ('Administrator','Moze zarzadzac uzytkownikami a takze ich postami oraz komentarzami oraz sam moze tworzyc posty i komentowac');
INSERT INTO role (Rola,opis) VALUES ('Uzytkownik', 'Moze dodawac, edytowac i usuwac swoje posty a takze komentowac posty innych uzytkownikow');

INSERT INTO category (Kategoria,Opis) VALUES ('Buildy', 'Porady na temat w jaki sposob rozwinac swoja postac');
INSERT INTO category (Kategoria,Opis) VALUES ('Bossowie', 'Rozmowy a takze porady jak pokonac danych bossow lub przeciwnikow');
INSERT INTO category (Kategoria,Opis) VALUES ('Ogolne', 'Rozmowy na ogolne tematy');
INSERT INTO category (Kategoria,Opis) VALUES ('Osiagniecia', 'Podpowiedzi i rozmowy jak zdobyc dane osiagniecia');

INSERT INTO users (role_id,nick,haslo) VALUES (1,'Nerazeem','zaq12wsx');
INSERT INTO users (nick,haslo) VALUES ('Aterves','hasior74');
INSERT INTO users (nick,haslo) VALUES ('PSforEver','ps4fanboy');
INSERT INTO users (nick,haslo) VALUES ('Sunny','slonce92');

INSERT INTO posts (kategoria_id,user_id,Temat,gra,tresc,data_dodania) VALUES (2,1,'Ornstein i Smough','Dark Souls','Jaka bron bedzie najlepsza przeciw Ornsteinowi i Smoughowi?','2019-04-09');

INSERT INTO comments (post_id,user_id,tresc) VALUES (1,3,'Ja polecam bardzo Miecz Czarnego Rycerza. Przeszedłem nim ok 2/3 gry i nim dawałem w miare rade przeciwko praktycznie kazdemu bossowi. Potrafilem ok 150 dmg jednym strzalem zabrac Ornsteinowi w pierwszej fazie walki');
INSERT INTO comments (post_id,user_id,tresc) VALUES (1,2,'Zalezy jaka profesja bedziesz grac. Pod wojownika okaze sie bardzo dobry Miecz Czarnego Rycerza +4 lub +5');


