import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { itemMovimentado } from '../../../models/itemMovimentado';
import { FormsModule } from '@angular/forms';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { ModalDinamicoComponent } from '../modal-dinamico/modal-dinamico.component';
import { MovimentacaoService } from '../../../core/services/movimentacao.service';
import { movimentacao } from '../../../models/movimentacao';
import { local } from '../../../models/local';
import { LocalService } from '../../../core/services/local.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { unidade } from '../../../models/unidade.model';
import { UnidadeService } from '../../../core/services/unidade/unidade.service';
import { ModalService } from '../../../core/services/modal/modal.service';

@Component({
  selector: 'app-adicionar-movimentacao',
  standalone: true,
  imports: [
    MatIconModule,
    CommonModule,
    FormsModule,
    MatDialogModule,
    MatButtonModule,
  ],
  templateUrl: './adicionar-movimentacao.component.html',
  styleUrl: './adicionar-movimentacao.component.css',
})
export class AdicionarMovimentacaoComponent {
  itensLista: itemMovimentado[] = [];
  listaUnidade$!: Observable<unidade[]>;
  listaLocais$!: Observable<local[]>;
  movimentacao: movimentacao = {} as movimentacao;
  dataMovimentacao = new Date();
  retro: boolean = false;
  nome: string = '';
  quantidade: number = 0;
  unidade: string = '';
  quimico: boolean = false;
  tipo: string = '';
  solicitante: string = '';
  responsavel: string = 'William Silva';
  local: string = '';

  constructor(
    private dialog: ModalService,
    private movimentacaoService: MovimentacaoService,
    private localService: LocalService,
    private unidadeService: UnidadeService,
  ) {
    this.listarLocais();
    this.listarUnidade();
  }

  dataMovimentoRetro(event: any) {
    if (event.target.checked) {
      this.retro = true;
    } else {
      this.retro = false;
    }
  }

  produtoQuimico(event: any) {
    if (event.target.checked) {
      this.quimico = true;
    } else {
      this.quimico = false;
    }
  }

  selecionarTipo(event: any) {
    this.tipo = event.target.value;
  }

  selecionarUnidade(event: any) {
    this.unidade = event.target.value;
  }

  selecionarLocal(event: any) {
    this.local = event.target.value;
  }

  adicionarItemLista() {
    if (
      !this.nome ||
      this.quantidade <= 0 ||
      !this.unidade ||
      !this.solicitante
    ) {
      this.dialog.modalAlerta(
        'Campos Vazios',
        'Você deve preencher todos os campos.',
      );
    } else {
      const novoItem = {
        nome: this.nome,
        quantidade: this.quantidade,
        unidade: this.unidade,
        produtoQuimico: this.quimico,
        tipo: this.tipo,
      };

      this.itensLista.push(novoItem);

      // Limpar inputs
      this.nome = '';
      this.quantidade = 0;
      this.unidade = '';
    }
  }

  listarLocais() {
    this.listaLocais$ = this.localService.buscarLocais();
  }

  listarUnidade() {
    this.listaUnidade$ = this.unidadeService.buscarUnidades();
  }

  salvarLancamento() {
    this.movimentacao.dataMovimentacao = this.dataMovimentacao;
    this.movimentacao.local = this.local;
    this.movimentacao.solicitante = this.solicitante;
    this.movimentacao.responsavel = this.responsavel;
    this.movimentacao.itensMovimentados = this.itensLista;

    this.movimentacaoService.salvarMovimentacao(this.movimentacao).subscribe({
      next: () => {
        this.dialog.modalSucesso('Sucesso', 'Movimentação criada com sucesso!');
        this.itensLista = [];
      },
      error: (err) =>
        this.dialog.modalErro(
          'Erro',
          'Ocorreu um erro ao salvar movimentação!',
        ),
    });
  }
}
