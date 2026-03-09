import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogModule,
} from '@angular/material/dialog';

@Component({
  selector: 'app-modal-dinamico',
  standalone: true,
  templateUrl: './modal-dinamico.component.html',
  styleUrl: './modal.css',
  imports: [
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
})
export class ModalDinamicoComponent {
  form!: FormGroup;
  modalSucesso: boolean = false;
  modalErro: boolean = false;
  modalConfirmacao: boolean = false;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<ModalDinamicoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    this.criarFormulario();
  }

  criarFormulario() {
    const group: any = {};

    this.data.campos.forEach((campo: any) => {
      group[campo.name] = [''];
    });

    this.form = this.fb.group(group);
  }
}
