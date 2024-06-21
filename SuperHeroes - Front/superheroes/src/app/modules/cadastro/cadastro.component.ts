import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormularioComponent } from '../../shared/formulario/formulario.component';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule, FormularioComponent, RouterModule,MatButtonModule, MatIconModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.scss'
})
export class CadastroComponent {
  constructor(private router: Router) { }

  goBack(){
    this.router.navigate(['/'])
  }
}
