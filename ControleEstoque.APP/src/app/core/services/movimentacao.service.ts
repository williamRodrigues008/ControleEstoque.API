import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams, HttpStatusCode } from '@angular/common/http';
import { movimentacao } from '../../models/movimentacao';
import { map, Observable } from 'rxjs';
import { PagedResult } from '../../models/pagedResult';
import { itemMovimentado } from '../../models/itemMovimentado';

@Injectable({
  providedIn: 'root',
})
export class MovimentacaoService {
  private url = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMovimentacao(
    pagina: number,
    quantidadePorPagina: number,
  ): Observable<PagedResult<movimentacao>> {
    const params = new HttpParams()
      .set('pagina', pagina)
      .set('quantidadePorPagina', quantidadePorPagina);

    return this.http.get<PagedResult<movimentacao>>(
      `${this.url}/api/Movimentacao/ListarMovimentacoes`,
      { params },
    );
  }

  buscarMovimentacaoPorId(id: number) {
    const params = new HttpParams().set('id', id);
    return this.http.get<any>(
      `${this.url}/api/Movimentacao/BuscarMovimentacaoPorId`,
      { params },
    );
  }

  salvarMovimentacao(mov: movimentacao) {
    return this.http.post<void>(
      `${this.url}/api/Movimentacao/AdicionarMovimentacaoInsumo`,
      mov,
    );
  }

  excluirMovimentacao(id: number) {
    return this.http.delete<void>(
      `${this.url}/api/Movimentacao/ExcluirMovimentacao/${id}`,
    );
  }

  listarItensMovimentados(id: number) {
    return this.http
      .post<
        itemMovimentado[]
      >(`${this.url}/api/Movimentacao/ListarItensMovimentados`, id)
      .pipe(map((m) => m ?? []));
  }

  atualizarMovimentacao(movimentacao: movimentacao) {
    return this.http.put<void>(
      `${this.url}/api/Movimentacao/AtualizarMovimentacao`,
      movimentacao,
    );
  }
}
