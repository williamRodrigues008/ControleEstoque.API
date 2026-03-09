import { Injectable } from '@angular/core';
import { ModalDinamicoComponent } from '../../../components/modalcomponents/modal-dinamico/modal-dinamico.component';
import { MatDialog } from '@angular/material/dialog';

@Injectable({
  providedIn: 'root',
})
export class ModalService {
  constructor(private dialog: MatDialog) {}

  modalSucesso(tituloMensagem: string, mensagem: string) {
    return this.dialog.open(ModalDinamicoComponent, {
      width: 'auto',
      height: 'auto',
      panelClass: ['custom-dialog'],
      backdropClass: 'custom-backdrop',
      data: {
        tipo: 'success',
        color: 'success',
        icone: 'verified',
        titulo: tituloMensagem,
        campos: [{ label: mensagem }],
      },
    });
  }

  modalAlerta(tituloMensagem: string, mensagem: string) {
    return this.dialog.open(ModalDinamicoComponent, {
      width: 'auto',
      height: 'auto',
      panelClass: ['custom-dialog'],
      backdropClass: 'custom-backdrop',
      data: {
        tipo: 'alerta',
        color: 'warning',
        icone: 'warning',
        titulo: tituloMensagem,
        campos: [{ label: mensagem }],
      },
    });
  }

  modalConfirmacao(tituloMensagem: string, mensagem: string) {
    return this.dialog.open(ModalDinamicoComponent, {
      width: 'auto',
      height: 'auto',
      panelClass: ['custom-dialog'],
      backdropClass: 'custom-backdrop',
      data: {
        tipo: 'confirm',
        color: 'primary',
        icone: 'person_raised_hand',
        titulo: tituloMensagem,
        campos: [{ label: mensagem }],
      },
    });
  }

  modalErro(tituloMensagem: string, mensagem: string) {
    return this.dialog.open(ModalDinamicoComponent, {
      width: 'auto',
      height: 'auto',
      panelClass: ['custom-dialog'],
      backdropClass: 'custom-backdrop',
      data: {
        tipo: 'error',
        color: 'danger',
        icone: 'error',
        titulo: tituloMensagem,
        campos: [{ label: mensagem }],
      },
    });
  }
}
