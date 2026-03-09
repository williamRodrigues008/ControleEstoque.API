import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InsumoComponent } from './components/insumo/insumo.component';
import { NotFoundError } from 'rxjs';
import { MovimentacaoComponent } from './components/movimentacao/movimentacao.component';
import { AdicionarMovimentacaoComponent } from './components/modalcomponents/adicionar-movimentacao/adicionar-movimentacao.component';
import { ExibirItensComponent } from './components/modalcomponents/exibir-itens/exibir-itens.component';
import { EditarMovimentacaoComponent } from './components/editar-movimentacao/editar-movimentacao.component';

export const routes: Routes = [
  { path: 'home', component: MovimentacaoComponent },
  { path: "insumos", component: InsumoComponent},
  { path: "novaMovimentacao", component: AdicionarMovimentacaoComponent },
  { path: "listarItensMovimentados/:id", component: ExibirItensComponent },
  { path: "editarMovimentacao/:id", component: EditarMovimentacaoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
