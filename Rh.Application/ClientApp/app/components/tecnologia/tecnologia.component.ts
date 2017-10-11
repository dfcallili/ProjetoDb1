import { Component, OnInit } from '@angular/core';
import { Tecnologia } from '../../_models/index';
import { TecnologiaService } from '../../_services/index';
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';

class TecnologiaInfo implements Tecnologia {
    constructor(public tecnologiaId: number, public nome: string) { }
}

@Component({
    selector: 'tecnologia',
    templateUrl: './tecnologia.component.html'
})
export class TecnologiaComponent implements OnInit {

    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    novaTecnologia: boolean;
    tecnologia: Tecnologia = new TecnologiaInfo(0, "");
    tecnologias: Tecnologia[];
    public editTecnologiaId: any;
    public nomeRemover?: string;

    constructor(private tecnologiaService: TecnologiaService, private toastrService: ToastrService) {

    }

    ngOnInit() {
        this.editTecnologiaId = 0;
        this.loadData();
    }

    loadData() {
        this.tecnologiaService.get()
            .subscribe(res => {
                console.log(res);
                this.rowData = res;
            });
    }

    showDialogToAdd() {
        this.novaTecnologia = true;
        this.editTecnologiaId = 0;
        this.tecnologia = new TecnologiaInfo(0, "");
        this.displayDialog = true;
    }


    showDialogToEdit(tecnologia: Tecnologia) {
        this.novaTecnologia = false;
        this.tecnologia = new TecnologiaInfo(0, "");
        this.tecnologia.tecnologiaId = tecnologia.tecnologiaId;
        this.tecnologia.nome = tecnologia.nome;
        this.displayDialog = true;
    }

    //onRowSelect(event) {
    //}

    salvar() {
        this.tecnologiaService.save(this.tecnologia)
            .subscribe(response => {
                this.toastrService.success('Tecnologia Cadastrada com Sucesso.');
                this.loadData();
            });
        this.displayDialog = false;
    }

    atualizar() {
        this.tecnologiaService.update(this.tecnologia)
            .subscribe(response => {
                this.toastrService.success('Tecnologia Atualizada com Sucesso.');
                this.loadData();
            });
        this.displayDialog = false;
    }

    voltar() {
        this.tecnologia = new TecnologiaInfo(0, "");
        this.displayDialog = false;
    }


    showDialogToDelete(tecnologia: Tecnologia) {
        this.nomeRemover = tecnologia.nome;
        this.editTecnologiaId = tecnologia.tecnologiaId;
        this.displayDeleteDialog = true;
    }

    okDelete(isDeleteConfirm: boolean) {
        if (isDeleteConfirm) {
            this.tecnologiaService.delete(this.editTecnologiaId)
                .subscribe(response => {
                    this.toastrService.success('Tecnologia Removida com Sucesso.');
                    this.loadData();
                    this.editTecnologiaId = 0;

                });
        }
        this.displayDeleteDialog = false;
    }
}