fac(0,1).
fac(N,R):-
    N>0,
    N1 is N-1,
    fac(N1,R1),
    R is N*R1.