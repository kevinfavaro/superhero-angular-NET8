import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { CadastroComponent } from './modules/cadastro/cadastro.component';
import { NgModule } from '@angular/core';
import { HttpClientModule, provideHttpClient } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
      },
      {
        path: 'cadastrar-heroi',
        component: CadastroComponent,
      },
];

@NgModule({
    imports: [RouterModule.forRoot(routes), HttpClientModule, FormsModule, ReactiveFormsModule, MatSnackBarModule],
    providers: [provideHttpClient()],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }