/*
 * síntomas
 */
sintoma(tos).
sintoma(fiebre).
sintoma(cuerpo_cortado).
sintoma(diarrea).

/*
 * enfermedades
 */
enfermedad(intoxicacion_estomacal).
enfermedad(covid19).
enfermedad(gripe).

/*
 * las enfermedades tienen síntomas
 */
sintoma_de(diarrea,intoxicacion_estomacal).
sintoma_de(tos,covid19).
sintoma_de(fiebre,covid19).
sintoma_de(cuerpo_cortado,tos).
sintoma_de(tos,gripe).

/*
 * medicamentos
 */
medicamento(aspirina).
medicamento(lomotil).

/*
 * los medicamentos curan síntomas
 */
cura(aspirina,fiebre).
cura(lomotil,diarrea).

/*
 * pacientes
 */
paciente(juancho).
paciente(maria).
paciente(nepomuceno).

/*
 * los pacientes tienen enfermedades o síntomas
 */
padece(juancho,tos).
padece(juancho,fiebre).
padece(maria,tos).
padece(nepomuceno,intoxicacion_estomacal).

/*
 * RULES
 */

/*
 * X alivia Y, si X es un medicamento y, 
 * Y es una enfermedad y X cura alguno de sus síntomas o
 * Y es un síntoma y X cura ese síntoma.
 */ 
alivia(X,Y):-medicamento(X),
    ((enfermedad(Y),
         sintoma_de(Z,Y),
         cura(X,Z))|(sintoma(Y),
                        cura(X,Y))).

/*
 * X es tratamiento para Y, si Y es un paciente, y
 * Y padece Z, y X alivia Z
 */
tratamiento(X,Y):-paciente(Y),padece(Y,Z),alivia(X,Z).

/*
 * X es una dolencia de Y, si Y es un paciente, y
 * X es una enfermedad 
 */
dolencias(X,Y):-paciente(Y),padece(Y,X),enfermedad(X).

/*
 * X es un síntoma de Y, si Y es un paciente, y
 * X es una síntoma 
 */
sintomas(X,Y):-paciente(Y),padece(Y,X),sintoma(X).

/*
 * X y Y comparten Z, si X es un paciente y Y también, y
 * X y Y no son iguales, y
 * Z es un síntoma que comparten X y Y
 */
comparten(X,Y,Z):-paciente(X),
    paciente(Y),
    not(X == Y),
    sintomas(Z,X),
    sintomas(Z,Y).