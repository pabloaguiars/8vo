es(gato,mamifero).
es(oso,mamifero).
es(mamifero, animal).
es(pez,animal).
es(ballena,mamifero).

tiene(gato,pelo).
tiene(oso,pelo).

vive(pez,agua).
vive(ballena,agua).

animal(X):-es(X,animal);(es(X,Y), animal(Y)).
pelo(X):-tiene(X,pelo).
acuatico(X):-vive(X,agua).

mamifero(A,B,C):-animal(A),es(A,B),(tiene(A,C);vive(A,C)).