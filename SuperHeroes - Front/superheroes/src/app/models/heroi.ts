import { Superpoderes } from "./superpoderes";

export class Heroi{
  id?: number;
  nome: string | undefined;
  nomeHeroi: string | undefined;
  dataNascimento: Date | undefined;
  altura: number | undefined;
  peso: number | undefined;
  superpoderes?: Array<Superpoderes>
}