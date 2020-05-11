person(franklin).
person(rerun).
person(peppermint_patty).
person(charlie_brown).
person(sally).
person(linus).
person(pigpen).
person(marcie).
person(lucy).
person(schroeder).
person(the_little_red_haired_girl).
animal(snoopy).
animal(woodstock).

pet(snoopy,chalie_brown).
would_have(rerun,snoopy).

crush(charlie_brown,peppermint_patty).
crush(linus,sally).
crush(schroeder,lucy).
crush(charlie_brown,marcie).
crush(the_little_red_haired_girl,charlie_brown).

best_friend(snoopy,woodstock).
best_friend(marcie,peppermint_patty).
best_friend(peppermint_patty,marcie).

younger_brother(linus,lucy).
younger_brother(rerun,linus).
younger_brother(sally,chalie_brown).

dance(peppermint_patty,pigpen).

classmates(franklin,peppermint_patty).

bother(lucy,chalie_brown).

older_brother(X,Y):-younger_brother(Y,X).