﻿import { Component, OnInit } from '@angular/core';
import { Vaga, VagaTecnologia, Tecnologia, TecnologiaVagaCriar } from '../../_models/index';
import { VagaService, TecnologiaService } from '../../_services/index';
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, CheckboxModule } from 'primeng/primeng';

class VagaInfo implements Vaga {
    constructor(public vagaId: number, public descricao: string, public listaVagaTecnologia: VagaTecnologia[], public selectedTecnologia: number[], public vagaJaEntrevistada: boolean) { }
}



@Component({
    selector: 'vaga',
    templateUrl: './vaga.component.html'
})
export class VagaComponent implements OnInit {

    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    displayDialogEditar: boolean;
    displayDialogPeso: boolean;
    displayListaClassificacao: boolean;
    novaVaga: boolean;
    vaga: Vaga = new VagaInfo(0, "", [], [], false);
    vagas: Vaga[];
    tecnologias: TecnologiaVagaCriar[];
    selectedTecnologia: number[];
    public editVagaId: any;
    public nomeRemover?: string;
    public labelCadastrarEditar: string;
    listTecnologiaPeso: VagaTecnologia[];
    listClassificacao: any[];


    constructor(private vagaService: VagaService, private tecnologiaServive: TecnologiaService, private toastrService: ToastrService) {

    }

    ngOnInit() {
        this.editVagaId = 0;
        this.loadData();
        this.selectedTecnologia = [];
    }

    loadData() {
        this.vagaService.get()
            .subscribe(res => {
                console.log(res);
                this.rowData = res;
            });
    }

    showDialogToAdd() {
        this.novaVaga = true;
        this.editVagaId = 0;
        this.vaga = new VagaInfo(0, "",[],[], false);
        this.displayDialog = true;
        this.labelCadastrarEditar = "Cadastrar Vaga";
        this.selectedTecnologia = [];

        this.listarTecnologias();
    }


    showDialogToEdit(vaga: Vaga) {
        this.novaVaga = false;
        this.listarTecnologias();

        this.labelCadastrarEditar = "Editar Vaga";
        this.selectedTecnologia = [];



        this.vagaService.getById(vaga.vagaId).subscribe(res => {
            this.vaga = res;

            for (var _i = 0; _i < this.vaga.listaVagaTecnologia.length; _i++) {

                let index = this.tecnologias.findIndex(d => d.tecnologiaId === this.vaga.listaVagaTecnologia[_i].tecnologiaId);
                if (index > -1) {
                    this.tecnologias[index].selected = true;
                }
                console.log(_i);
                this.vaga.listaVagaTecnologia[_i].selected = true;
                this.selectedTecnologia.push(this.vaga.listaVagaTecnologia[_i].tecnologiaId);
            }
        });
        this.displayDialogEditar = true;
    }

    showDialogToDetail(vaga: Vaga) {
        this.novaVaga = false;
        //this.listarTecnologias();

        this.labelCadastrarEditar = "Calcular Classificados";
        this.selectedTecnologia = [];

        this.vagaService.getById(vaga.vagaId).subscribe(res => {
            this.vaga = res;

            this.vagaService.getTecnologiaByVagaId(vaga.vagaId).subscribe(t => {
                this.listTecnologiaPeso = t;
            });
            //for (var _i = 0; _i < this.vaga.listaVagaTecnologia.length; _i++) {

            //    let index = this.tecnologias.findIndex(d => d.tecnologiaId === this.vaga.listaVagaTecnologia[_i].tecnologiaId);
            //    if (index > -1) {
            //        this.tecnologias[index].selected = true;
            //    }
            //    console.log(_i);
            //    this.vaga.listaVagaTecnologia[_i].selected = true;
            //    this.selectedTecnologia.push(this.vaga.listaVagaTecnologia[_i].tecnologiaId);
            //}
        });
        this.displayDialogPeso = true;
    }

    selecionaTecnologia(tecnologia: Tecnologia) {
        console.log(this.selectedTecnologia);
        let index = this.selectedTecnologia.findIndex(d => d === tecnologia.tecnologiaId);
        if (index > -1)
            this.selectedTecnologia.splice(index, 1);
        else
            this.selectedTecnologia.push(tecnologia.tecnologiaId);

        console.log(this.selectedTecnologia);
    }

    listarTecnologias() {
        this.tecnologiaServive.get().subscribe(res => {
            this.tecnologias = res;
        });
    }

    salvar() {
        let vagaDto: Vaga = new VagaInfo(this.vaga.vagaId, this.vaga.descricao, [],[], false);
        for (var _i = 0; _i < this.selectedTecnologia.length; _i++) {
            vagaDto.listaVagaTecnologia.push({ vagaTecnologiaId: 0, vagaId: 0, tecnologiaId: this.selectedTecnologia[_i], peso: 0, selected: true }); 

        }

        console.log(vagaDto);
        this.vagaService.save(vagaDto)
            .subscribe(response => {
                this.toastrService.success('Vaga Cadastrada com Sucesso.');
                this.loadData();
            });
        this.displayDialog = false;
    }

    atualizar() {
        this.vagaService.update(this.vaga)
            .subscribe(response => {
                this.toastrService.success('Vaga Atualizada com Sucesso.');
                this.loadData();
            });
        this.displayDialog = false;
    }

    voltar() {
        this.vaga = new VagaInfo(0, "",[],[], false);
        this.displayDialog = false;
        this.displayDialogEditar = false;
        this.displayDialogPeso = false;
        this.displayListaClassificacao = false;
        this.selectedTecnologia = [];
        this.listTecnologiaPeso = [];
        this.listClassificacao = [];
    }

    calcularClassificao() {
        let vagaDto: Vaga = new VagaInfo(this.vaga.vagaId, this.vaga.descricao, [], [], false);
        for (var _i = 0; _i < this.listTecnologiaPeso.length; _i++) {
            vagaDto.listaVagaTecnologia.push({ vagaTecnologiaId: this.listTecnologiaPeso[_i].vagaTecnologiaId, vagaId: this.listTecnologiaPeso[_i].vagaId, tecnologiaId: this.listTecnologiaPeso[_i].tecnologiaId, peso: this.listTecnologiaPeso[_i].peso, selected: true });

        }

        console.log(vagaDto);

        this.vagaService.calcularClassificao(vagaDto)
            .subscribe(res => {
                console.log(res);
                this.listClassificacao = res;
                this.displayListaClassificacao = true;
            });
    }


    showDialogToDelete(Vaga: Vaga) {
        this.nomeRemover = Vaga.descricao;
        this.editVagaId = Vaga.vagaId;
        this.displayDeleteDialog = true;
    }

    okDelete(isDeleteConfirm: boolean) {
        if (isDeleteConfirm) {
            this.vagaService.delete(this.editVagaId)
                .subscribe(response => {
                    this.toastrService.success('Vaga Removida com Sucesso.');
                    this.loadData();
                    this.editVagaId = 0;

                });
        }
        this.displayDeleteDialog = false;
    }
}