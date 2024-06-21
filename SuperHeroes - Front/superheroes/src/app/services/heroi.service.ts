import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Heroi } from '../models/heroi';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeroiService {
  private url: string = 'https://localhost:7263/Herois';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    })
  };

  constructor(private http: HttpClient) { }

  cadastrarNovoHeroi(novoHeroi: Heroi): Observable<Heroi> {
    return this.http.post<Heroi>(this.url, novoHeroi, this.httpOptions);
  }

  AtualizarHeroi(id: number, novoHeroi: Heroi): Observable<any> {
    return this.http.put(`${this.url}/${id}`, novoHeroi, this.httpOptions);
  }

  GetHeroiById(id: number): Observable<Heroi> {
    return this.http.get<Heroi>(`${this.url}/${id}`, this.httpOptions);
  }

  ListarHerois(): Observable<Heroi[]> {
    return this.http.get<Heroi[]>(`${this.url}`, this.httpOptions);
  }

  ExcluirHeroi(id: number) {
    return this.http.delete(`${this.url}/${id}`, this.httpOptions);
  }
}

