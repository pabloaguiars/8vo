/*
 * offers list
 */
offer(a,[1,2,3],30).
offer(b,[1,2,3],20).
offer(c,[4],20).
offer(d,[2,4],20).
offer(e,[1,2],20).

/*
 * find if the offer is in the offers list
 */
offers(L):-findall(O,offer(O,_,_),L).

/*
 * These sets are used to form 
 * each of the possible sets between offers.
 */
subset([], []).
subset([X|L1],[X|L2]):- subset(L1, L2).
subset(L1,[_|L2]):- subset(L1, L2).

/*
 * accept or not a offer
 */
isAcceptable(L):- not(notAcceptable(L)).
notAcceptable(L):-
    member(O1, L), 
    member(O2, L), 
    O1 \= O2, 
    offer(O1, L1, _),
    offer(O2, L2, _),
    isRepeated(L1, L2).

isRepeated(L1, L2):-member(X, L1), member(X, L2).

/*
 * choose between offers to find best profits
 */
profit([], 0).
profit([O|L], G):-offer(O, _, G1), profit(L, G2), G is G1 + G2.

/*
 *  determines if is a offer is acceptable
 */
acceptable(L):-offers(L1), subset(L, L1), isAcceptable(L).

/*
 * rule to check if a offer is accepted
 */
accepted(L):-
    acceptable(L), 
    profit(L, G), 
    not((acceptable(L1),
            profit(L1, G1), 
        	G1>G)).