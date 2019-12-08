USE best_logistic

CREATE TABLE dbo.route
(
	departure_point varchar(255),
	arrival_point varchar(255),
	PRIMARY KEY (departure_point, arrival_point),
	FOREIGN KEY (departure_point) REFERENCES dbo.point,
	FOREIGN KEY (arrival_point) REFERENCES dbo.point,
)

-- nilai -> bangi
INSERT INTO dbo.route VALUES ('ChIJw06LDtrFzTER578ZF_6Z-gg', 'ChIJ7ZqvbEzKzTER-r67V-ufxtg');
INSERT INTO dbo.route VALUES ('ChIJ7ZqvbEzKzTER-r67V-ufxtg', 'ChIJw06LDtrFzTER578ZF_6Z-gg');
-- bangi -> puchong
INSERT INTO dbo.route VALUES ('ChIJ7ZqvbEzKzTER-r67V-ufxtg', 'ChIJNWxC8VmzzTERVQYzQ66uwCM');
INSERT INTO dbo.route VALUES ('ChIJNWxC8VmzzTERVQYzQ66uwCM', 'ChIJ7ZqvbEzKzTER-r67V-ufxtg');
-- puchong -> sg.buloh
INSERT INTO dbo.route VALUES ('ChIJNWxC8VmzzTERVQYzQ66uwCM', 'ChIJIeom6DpOzDERFh89Ox4KCig');
INSERT INTO dbo.route VALUES ('ChIJIeom6DpOzDERFh89Ox4KCig', 'ChIJNWxC8VmzzTERVQYzQ66uwCM');
-- sg.buloh-> bkt.beruntung
INSERT INTO dbo.route VALUES ('ChIJIeom6DpOzDERFh89Ox4KCig', 'ChIJoxijCENpzDERzC5DDRq2J8E');
INSERT INTO dbo.route VALUES ('ChIJoxijCENpzDERzC5DDRq2J8E', 'ChIJIeom6DpOzDERFh89Ox4KCig');
-- bkt.beruntung -> ipoh
INSERT INTO dbo.route VALUES ('ChIJoxijCENpzDERzC5DDRq2J8E', 'ChIJexR2dy6TyjERVqDwNY8buBo');
INSERT INTO dbo.route VALUES ('ChIJexR2dy6TyjERVqDwNY8buBo', 'ChIJoxijCENpzDERzC5DDRq2J8E');
-- ipoh -> pekaka
INSERT INTO dbo.route VALUES ('ChIJexR2dy6TyjERVqDwNY8buBo', 'ChIJ7ciSyEquSjARqdvRktxutKI');
INSERT INTO dbo.route VALUES ('ChIJ7ciSyEquSjARqdvRktxutKI', 'ChIJexR2dy6TyjERVqDwNY8buBo');