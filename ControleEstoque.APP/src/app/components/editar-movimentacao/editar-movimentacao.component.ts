import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { movimentacao } from '../../models/movimentacao';
import { MovimentacaoService } from '../../core/services/movimentacao.service';
import { map, Observable, tap } from 'rxjs';
import { itemMovimentado } from '../../models/itemMovimentado';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { local } from '../../models/local';
import { LocalService } from '../../core/services/local.service';
import { UnidadeService } from '../../core/services/unidade/unidade.service';
import { unidade } from '../../models/unidade.model';
import { FormsModule } from '@angular/forms';
import { ModalDinamicoComponent } from '../modalcomponents/modal-dinamico/modal-dinamico.component';
import { ModalService } from '../../core/services/modal/modal.service';

@Component({
  selector: 'app-editar-movimentacao',
  standalone: true,
  imports: [CommonModule, MatIconModule, FormsModule],
  templateUrl: './editar-movimentacao.component.html',
  styleUrl: './editar-movimentacao.component.css',
})
export class EditarMovimentacaoComponent {
  movimentacao$!: Observable<movimentacao>;
  insumos: itemMovimentado[] = [];
  quimicos: itemMovimentado[] = [];
  listaLocais$!: Observable<local[]>;
  listaUnidade$!: Observable<unidade[]>;

  constructor(
    private route: ActivatedRoute,
    private movimentacaoService: MovimentacaoService,
    private localService: LocalService,
    private unidadeService: UnidadeService,
    private modalDialogo: ModalService,
  ) {}

  ngOnInit() {
    this.buscarMovimentacaoPorId();
    this.listarLocais();
    this.listarUnidade();
  }

  buscarMovimentacaoPorId() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.movimentacao$ = this.movimentacaoService
      .buscarMovimentacaoPorId(id)
      .pipe(
        tap((ret) => {
          this.quimicos = ret.itensMovimentados.filter((i) => i.produtoQuimico);
          this.insumos = ret.itensMovimentados.filter((i) => !i.produtoQuimico);
        }),
      );
  }

  atualizarMovimentacao(mov: movimentacao) {
    this.movimentacaoService.atualizarMovimentacao(mov).subscribe({
      next: () => {
        this.modalDialogo.modalSucesso(
          'Sucesso',
          'Alteração realizada com sucesso!',
        );
      },
      error: (erro) => {
        this.modalDialogo.modalErro(
          'Erro',
          'Ocorreu um erro ao salvar alteração',
        );
        console.error(erro);
      },
    });
  }

  adicionar(index: number, tipo: string) {
    if (tipo === 'insumo') this.insumos[index].quantidade++;
    if (tipo === 'quimico') this.quimicos[index].quantidade++;
  }

  subtrair(index: number, tipo: string) {
    if (tipo === 'insumo') this.insumos[index].quantidade--;
    if (tipo === 'quimico') this.quimicos[index].quantidade--;
  }

  listarLocais() {
    this.listaLocais$ = this.localService.buscarLocais();
  }

  listarUnidade() {
    this.listaUnidade$ = this.unidadeService.buscarUnidades();
  }
  selecionarUnidade(event: any) {
    return event.target.value;
  }
}
