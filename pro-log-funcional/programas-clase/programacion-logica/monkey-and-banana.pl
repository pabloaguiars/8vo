/*
 * state(
 * 	monkey position,
 * 	box position,
 * 	is the monkey on the box?, 
 * 	does the monkey have the banana?
 * )
 * 
 * state1 is the required conditions to do the action
 * action is the action we want to do
 * state2 is the result state after move
 * 
 * move(
 * 	state1,
 * 	action,
 * 	state2
 * ).
*/

/*
 * MOVES
 */

/* monkey gets the banana */
move(
	state(middle,B,yes,no),
    grasp,
    state(middle,B,yes,yes)
).

/* monkey climbs the box */
move(
	state(M,M,no,H),
    climb,
    state(M,M,yes,H)
).

/* monkey pushes the box to P destination */
move(
	state(M,M,no,H),
    push(P),
    state(P,P,no,H)
).

/* monkey walks to P destination */
move(
	state(M,B,no,H),
    walk(P),
    state(P,B,no,H)
).

/*
 * RULES
 */

/*
 * GOAL STATE
 */
get_banana(state(_,_,_,yes)).

/*
 * get next move, and check if monkey has the banana
 */
get_banana(State1):-
    move(State1,_,State2),
    get_banana(State2).