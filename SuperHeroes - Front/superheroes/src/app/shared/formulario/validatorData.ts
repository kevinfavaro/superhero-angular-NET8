import { AbstractControl } from "@angular/forms";

export function validatorData(control: AbstractControl) {
  const data = new Date(control.value);
  var dataAtual = new Date();

  if (dataAtual > data) {
    return { datafutura: true };
  } else {
    return null;
  }


}
export function idade(control: AbstractControl) {
  var hoje = new Date();
  const data = new Date(control.value);

  var diferencaAnos = hoje.getFullYear() - data.getFullYear();
  if ( new Date(hoje.getFullYear(), hoje.getMonth(), hoje.getDate()) <
       new Date(hoje.getFullYear(), data.getMonth(), data.getDate()) )
      diferencaAnos--;


      if (diferencaAnos > 15) {
        return true;
      } else {
        return {idade: "A idade do usuário não pode ser menor que 15 anos"};
      }
}
