hombre(abraham).
hombre(jackie).
hombre(herb).
hombre(homero).
hombre(bart).

mujer(mana).
mujer(clancy).
mujer(marge).
mujer(paty).
mujer(selma).
mujer(lisa).
mujer(maggie).
mujer(ling).

% PADRES
pariente(abraham,herb).
pariente(abraham,homero).

pariente(jackie,marge).
pariente(jackie,patty).
pariente(jackie,selma).

pariente(homero,bart).
pariente(homero,lisa).
pariente(homero,maggie).

% MADRES
pariente(mana,herb).
pariente(mana,homero).

pariente(clancy,marge).
pariente(clancy,patty).
pariente(clancy,selma).

pariente(marge,bart).
pariente(marge,lisa).
pariente(marge,maggie).

pariente(selma,ling).

matrimonio(Abraham,Mana).
matrimonio(Homero,Marge).
matrimonio(Clancy, Jackie).

% REGLAS
padre(X,Y) :- pariente(X,Y), hombre(X).
madre(X,Y) :- pariente(X,Y), mujer(X).
hermana(X,Y) :- pariente(Z,X),pariente(Z,Y),mujer(X),not(X=Y).
hermano(X,Y) :- pariente(Z,X),pariente(Z,Y),hombre(X),not(X=Y).
tio(X,Y) :- (hermano(X,Z)),(padre(Z,Y);madre(Z,Y)),hombre(X).
tia(X,Y) :- (hermana(X,Z)),(padre(Z,Y);madre(Z,Y)),mujer(X).
abuelo(X,Y) :- padre(X,Z),(padre(Z,Y);madre(Z,Y)),hombre(X).
abuela(X,Y) :- madre(X,Z),(padre(Z,Y);madre(Z,Y)),mujer(X).
mascota(X,Y) :- pariente(Y,X),animal(X).
