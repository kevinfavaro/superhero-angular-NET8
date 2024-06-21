import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { HeroiService } from '../../services/heroi.service';
import { Router } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import { SearchInputComponent } from '../search-input/search-input.component';
import { DialogService } from '../../services/dialog.service';
import { Heroi } from '../../models/heroi';

@Component({
  selector: 'app-lista-herois',
  standalone: true,
  imports: [CommonModule,SearchInputComponent,MatCardModule,MatFormFieldModule,MatButtonModule,MatDividerModule],
  templateUrl: './lista-herois.component.html',
  styleUrls: ['./lista-herois.component.scss']
})
export class ListaHeroisComponent {
  private listaHerois?: any[];
  public getAllHerois?: any[];

  constructor(private heroiService: HeroiService,private dialogService: DialogService,private router: Router) { }

  ngOnInit(): void {
    this.heroiService.ListarHerois().subscribe({
      next: (data) => {
        console.log(data);
        this.listaHerois = data;
        this.getAllHerois = this.listaHerois
      },
      error: (error: any) => {
        this.dialogService.openSnackBar(JSON.stringify(error?.error), "OK", 4000)
      }
    });
  }


  removeHeroi(id: number) {
    this.heroiService.ExcluirHeroi(id).subscribe({
      next: () => {
        this.ngOnInit();
        this.dialogService.openSnackBar(JSON.stringify("Herói Excluído"), "OK", 4000)
      },
      error: (error: any) => {
        this.dialogService.openSnackBar(JSON.stringify(error?.error), "OK", 4000)
      }
    })
  }

  editarHeroi(idHeroi: number){
    this.router.navigate(['/cadastrar-heroi',{id: idHeroi} ])
  }

  public getSearch(value: string){
    const filter = this.listaHerois?.filter( (res: any ) => {
      return !res.nome.toLowerCase().indexOf(value.toLowerCase());
    });

    this.getAllHerois = filter;
  }
}
