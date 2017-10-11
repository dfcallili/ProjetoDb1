import { Component, OnInit } from '@angular/core';
import { Candidato } from '../../_models/index';
import { CandidatoService } from '../../_services/index';
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';

class CandidatoInfo implements Candidato {
    constructor(public candidatoId : number, public nome : string) { }
}

@Component({
    selector: 'candidato',
    templateUrl: './candidato.component.html'
})
export class CandidatoComponent implements OnInit {

    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    novoCandidato: boolean;
    candidato: Candidato = new CandidatoInfo(0, "");
    candidatos: Candidato[];
    public editCandidatoId: any;
    public nomeRemover?: string;

    constructor(private candidatoService: CandidatoService, private toastrService: ToastrService) {

    }

    ngOnInit() {
        this.editCandidatoId = 0;
        this.loadData();
    }

    loadData() {
        this.candidatoService.get()
            .subscribe(res => {
                console.log(res);
                this.rowData = res;
            });
    }

    showDialogToAdd() {
        this.novoCandidato = true;
        this.editCandidatoId = 0;
        this.candidato = new CandidatoInfo(0,"");
        this.displayDialog = true;
    }


    showDialogToEdit(candidato: Candidato) {
        this.novoCandidato = false;
        this.candidato = new CandidatoInfo(0,"");
        this.candidato.candidatoId = candidato.candidatoId;
        this.candidato.nome = candidato.nome;
        this.displayDialog = true;
    }

    //onRowSelect(event) {
    //}

    salvar() {
        this.candidatoService.save(this.candidato)
            .subscribe(response => {
                this.toastrService.success('Candidato Cadastrado com Sucesso.');
                this.loadData();
            });
        this.displayDialog = false;
    }

    atualizar() {
        this.candidatoService.update(this.candidato)
            .subscribe(response => {
                this.toastrService.success('Candidato Atualizado com Sucesso.');
                this.loadData();
            });
        this.displayDialog = false;
    }

    voltar() {
        this.candidato = new CandidatoInfo(0,"");
        this.displayDialog = false;
    }


    showDialogToDelete(candidato: Candidato) {
        this.nomeRemover = candidato.nome;
        this.editCandidatoId = candidato.candidatoId;
        this.displayDeleteDialog = true;
    }

    okDelete(isDeleteConfirm: boolean) {
        if (isDeleteConfirm) {
            this.candidatoService.delete(this.editCandidatoId)
                .subscribe(response => {
                    this.toastrService.success('Candidato Removido com Sucesso.');
                    this.loadData();
                    this.editCandidatoId = 0;

                });
        }
        this.displayDeleteDialog = false;
    }
}