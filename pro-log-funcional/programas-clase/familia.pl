% hechos simples
hombre(jorge).		% abuelo
hombre(fernando). 	% padre
hombre(hugo).		% tio
mujer(sofia).		% abuela
mujer(claudia).		% tia
mujer(maria).		% madre
mujer(faby).		% hija
mujer(diana).		% hija
animal(flopi).		% mascota

% hechos compuesto
pariente(jorge,fernando).
pariente(jorge,hugo).
pariente(jorge,claudia).

pariente(sofia,fernando).
pariente(sofia,hugo).
pariente(sofia,claudia).

pariente(fernando,diana). % Fernando es pariente de Diana
pariente(fernando,faby).

pariente(maria,diana).
pariente(maria,faby).

pariente(faby,flopi).	% mascota parte de la familia XD

matrimonio(jorge,sofia). % abuelos
matrimonio(fernando,maria). % padres
% mascota(flopi,faby).

% reglas
padre(X,Y) :- pariente(X,Y), hombre(X). % X es padre de Y, si es X es pariente de Y y X es hombre
madre(X,Y) :- pariente(X,Y), mujer(X).
hermana(X,Y) :- pariente(Z,X),pariente(Z,Y),mujer(X),not(X=Y).
hermano(X,Y) :- pariente(Z,X),pariente(Z,Y),hombre(X),not(X=Y).
tio(X,Y) :- (hermano(X,Z)),(padre(Z,Y);madre(Z,Y)),hombre(X).
tia(X,Y) :- (hermana(X,Z)),(padre(Z,Y);madre(Z,Y)),mujer(X).
abuelo(X,Y) :- padre(X,Z),(padre(Z,Y);madre(Z,Y)),hombre(X).
abuela(X,Y) :- madre(X,Z),(padre(Z,Y);madre(Z,Y)),mujer(X).
mascota(X,Y) :- pariente(Y,X),animal(X).
