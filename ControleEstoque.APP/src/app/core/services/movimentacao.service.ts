import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { movimentacao } from '../../models/movimentacao';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovimentacaoService {

  private url = environment.apiUrl;
  
  constructor(private http: HttpClient){}
  
  getMovimentacao(){
    return this.http.get<movimentacao[]>(`${this.url}/api/Movimentacao/ListarMovimentacoes`).pipe(
      map(mov => mov ?? [])
    );
  }
}
