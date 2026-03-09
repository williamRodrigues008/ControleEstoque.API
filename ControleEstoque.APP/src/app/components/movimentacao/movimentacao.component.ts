import { Component } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { movimentacao } from '../../models/movimentacao';
import { MovimentacaoService } from '../../core/services/movimentacao.service';
import { PagedResult } from '../../models/pagedResult';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { ModalService } from '../../core/services/modal/modal.service';

@Component({
  selector: 'app-movimentacao',
  standalone: true,
  imports: [CommonModule, RouterModule, MatIconModule],
  templateUrl: './movimentacao.component.html',
  styleUrl: './movimentacao.component.css',
})
export class MovimentacaoComponent {
  movimentacoes$!: Observable<PagedResult<movimentacao>>;
  paginaAtual = 1;
  quantidadePorPagina = 10;
  totalItens = 0;

  constructor(
    private movimentacaoService: MovimentacaoService,
    private modalDialogo: ModalService,
  ) {
    this.getMovimentacoes();
  }

  getMovimentacoes() {
    this.movimentacoes$ = this.movimentacaoService
      .getMovimentacao(this.paginaAtual, this.quantidadePorPagina)
      .pipe(tap((ret) => (this.totalItens = ret.total)));
  }

  excluirMovimentacoes(id: number) {
    console.log(id);

    this.modalDialogo
      .modalConfirmacao(
        'Você tem certeza?',
        'Deseja excluir esta movimentação?',
      )
      .afterClosed()
      .subscribe((resultado) => {
        console.log('resultado => ');

        console.log(resultado);

        if (resultado) {
          this.movimentacaoService.excluirMovimentacao(id).subscribe({
            next: () => {
              this.modalDialogo.modalSucesso(
                'Sucesso',
                'Movimentação excluída com sucesso!',
              );
              this.getMovimentacoes();
            },
            error: (erro) => {
              this.modalDialogo.modalErro(
                'Erro',
                'Ocorreu um erro ao tentar excluir a movimentação!',
              );
              console.log(erro);
            },
          });
        }
      });
  }

  mudarPagina(page: number) {
    this.paginaAtual = page;
    this.getMovimentacoes();
  }

  get totalPaginas(): number {
    return Math.ceil(this.totalItens / this.quantidadePorPagina);
  }

  get paginas(): number[] {
    return Array.from({ length: this.totalPaginas }, (_, i) => i + 1);
  }
}
