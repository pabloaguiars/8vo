/*
 * GOAL STATE
 */
goal([1,2,3, 4,5,6, 7,8,0]).

/*
 * RIGHT
 */ 
move([0,N1,N2, N3,N4,N5, N6,N7,N8],[N1,0,N2, N3,N4,N5, N6,N7,N8]).
move([N1,0,N2, N3,N4,N5, N6,N7,N8],[N1,N2,0, N3,N4,N5, N6,N7,N8]).
move([N1,N2,N3, 0,N4,N5, N6,N7,N8],[N1,N2,N3, N4,0,N5, N6,N7,N8]).
move([N1,N2,N3, N4,0,N5, N6,N7,N8],[N1,N2,N3, N4,N5,0, N6,N7,N8]).
move([N1,N2,N3, N4,N5,N6, 0,N7,N8],[N1,N2,N3, N4,N5,N6, N7,0,N8]).
move([N1,N2,N3, N4,N5,N6, N7,0,N8],[N1,N2,N3, N4,N5,N6, N7,N8,0]).

/*
 * DOWN
 */
move([0,N1,N2, N3,N4,N5, N6,N7,N8],[N3,N1,N2, 0,N4,N5, N6,N7,N8]).
move([N1,0,N2, N3,N4,N5, N6,N7,N8],[N1,N4,N2, N3,0,N5, N6,N7,N8]).
move([N1,N2,0, N3,N4,N5, N6,N7,N8],[N1,N2,N5, N3,N4,0, N6,N7,N8]).
move([N1,N2,N3, 0,N4,N5, N6,N7,N8],[N1,N2,N3, N6,N4,N5, 0,N7,N8]).
move([N1,N2,N3, N4,0,N5, N6,N7,N8],[N1,N2,N3, N4,N7,N5, N6,0,N8]).
move([N1,N2,N3, N4,N5,0, N6,N7,N8],[N1,N2,N3, N4,N5,N8, N6,N7,0]).

/*
 * LEFT 
 */
move([N1,0,N2, N3,N4,N5, N6,N7,N8],[0,N1,N2, N3,N4,N5, N6,N7,N8]).
move([N1,N2,0, N3,N4,N5, N6,N7,N8],[N1,0,N2, N3,N4,N5, N6,N7,N8]).
move([N1,N2,N3, N4,0,N5, N6,N7,N8],[N1,N2,N3, 0,N4,N5, N6,N7,N8]).
move([N1,N2,N3, N4,N5,0, N6,N7,N8],[N1,N2,N3, N4,0,N5, N6,N7,N8]).
move([N1,N2,N3, N4,N5,N6, N7,0,N8],[N1,N2,N3, N4,N5,N6, 0,N7,N8]).
move([N1,N2,N3, N4,N5,N6, N7,N8,0],[N1,N2,N3, N4,N5,N6, N7,0,N8]).

/*
 * UP
 */ 
move([N1,N2,N3, 0,N4,N5, N6,N7,N8],[0,N2,N3, N1,N4,N5, N6,N7,N8]).
move([N1,N2,N3, N4,0,N5, N6,N7,N8],[N1,0,N3, N4,N2,N5, N6,N7,N8]).
move([N1,N2,N3, N4,N5,0, N6,N7,N8],[N1,N2,0, N4,N5,N3, N6,N7,N8]).
move([N1,N2,N3, N4,N5,N6, 0,N7,N8],[N1,N2,N3, 0,N5,N6, N4,N7,N8]).
move([N1,N2,N3, N4,N5,N6, N7,0,N8],[N1,N2,N3, N4,0,N6, N7,N5,N8]).
move([N1,N2,N3, N4,N5,N6, N7,N8,0],[N1,N2,N3, N4,N5,0, N7,N8,N6]).

/* RULES
 * S: STATE
 * VS: VISITED STATES
 * R: RESULT
 * NS: NEW STATE
 * */
play(S,R,R):-goal(S).
play(S,VS,R):-move(S,NS),\+member(NS,VS),play(NS,[NS|VS],R).

/* TRY IT! 
 * play([1,2,3,4,5,0,6,7,8],[],R).
 */

