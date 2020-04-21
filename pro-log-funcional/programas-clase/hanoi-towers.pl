/*
 * basic movement, move 1 from A to B
 * print in this movement
 */
move(1,A,B,_):- 
    write('Move top disk from '),
    write(A),
    write(' to '),
    write(B),
    nl.

/*
 * N: number of disks
 * A: tower A (from, source, etc)
 * B: tower B (to, target, etc)
 * C: tower C (using, temp, aux, etc)
 * 
 * first, do if N > 1, because we shouldn't work with negative disks
 * second, move N-1 disks from A to C, using  B
 * third, move one disk from A to B
 * fourth, move N-1 disks from C to B, using A
 * FIFTH: DONE!
 */
move(N,A,B,C):- 
    N>1,
    M is N-1,
    move(M,A,C,B),
    move(1,A,B,_),
    move(M,C,B,A).