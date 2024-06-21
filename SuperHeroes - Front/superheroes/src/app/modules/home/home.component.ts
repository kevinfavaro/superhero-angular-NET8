import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ListaHeroisComponent } from '../../shared/lista-herois/lista-herois.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ListaHeroisComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
