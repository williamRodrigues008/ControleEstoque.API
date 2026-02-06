// produto.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Insumo } from './insumos.model';

@Injectable({
  providedIn: 'root'
})
export class InsumoService {

  private apiUrl = 'https://localhost:5001/api/produtos';

  constructor(private http: HttpClient) {}

  listar() {
    return this.http.get<insumo[]>(this.apiUrl);
  }
}
