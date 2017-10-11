import { Component, OnInit } from '@angular/core';
import { Entrevista, EntrevistaCriar, EntrevistaTecnologia, Tecnologia, VagaTecnologia, Vaga, Candidato, VagaTecnologiaEntrevista } from '../../_models/index';
import { EntrevistaService, TecnologiaService, VagaService, CandidatoService } from '../../_services/index';
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, CheckboxModule } from 'primeng/primeng';

class EntrevistaInfo implements EntrevistaCriar {
    constructor(public entrevistaId: number, public vagaId: number, public candidatoId: number, public dataEntrevista: Date, public listaEntrevistaTecnologia: EntrevistaTecnologia[], public selectedTecnologia: number[]) { }
}



@Component({
    selector: 'entrevista',
    templateUrl: './entrevista.component.html'
})
export class EntrevistaComponent implements OnInit {

    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    displayDialogDetail: boolean;
    novaEntrevista: boolean;
    entrevista: EntrevistaCriar = new EntrevistaInfo(0, 0, 0, new Date(), [], []);
    entrevistas: Entrevista[];
    tecnologias: Tecnologia[];
    selectedTecnologia: number[];
    public editEntrevistaId: any;
    public nomeRemover?: string;
    public labelCadastrarEditar: string;
    vagaAtualId: number;
    vagas: Vaga[];
    candidatoAtualId: number;
    candidatos: Candidato[];

    constructor(private entrevistaService: EntrevistaService, private vagaService: VagaService, private candidatoService: CandidatoService, private toastrService: ToastrService) {

    }

    ngOnInit() {
        this.editEntrevistaId = 0;
        this.loadData();
        this.selectedTecnologia = [];
    }

    loadData() {
        this.entrevistaService.get()
            .subscribe(res => {
                console.log(res);
                this.rowData = res;
            });
    }

    showDialogToAdd() {
        this.displayDialogDetail = false;
        this.novaEntrevista = true;
        this.vagaAtualId = 0;
        this.candidatoAtualId = 0;
        this.entrevista = new EntrevistaInfo(0, 0, 0, new Date(), [], []);
        this.labelCadastrarEditar = "Cadastrar Entrevista";
        this.selectedTecnologia = [];

        this.candidatoService.get().subscribe(res => {
            this.candidatos = res;
        });

        this.vagaService.get().subscribe(res => {
            this.vagas = res;
        });

        this.displayDialog = true;
    }

    selecionaTecnologia(vagaTecnologiaId: number) {
        console.log(this.selectedTecnologia);
        let index = this.selectedTecnologia.findIndex(d => d === vagaTecnologiaId);
        if (index > -1)
            this.selectedTecnologia.splice(index, 1);
        else
            this.selectedTecnologia.push(vagaTecnologiaId);

        console.log(this.selectedTecnologia);
    }

    buscaTecnologias() {
        console.log(this.vagaAtualId);
        if (this.vagaAtualId > 0) {
            this.vagaService.getTecnologiaByVagaId(this.vagaAtualId).subscribe(res => {
                this.tecnologias = res;
            });
        }
        else {
            this.tecnologias = [];
        }
    }

    salvar() {
        if (this.candidatoAtualId == 0) {
            this.toastrService.warning("Informe o Candidato que está realizando esta Entrevista.");
            return;
        }

        if (this.vagaAtualId == 0) {
            this.toastrService.warning("Informe a Vaga desta Entrevista.");
            return;
        }

        if (this.selectedTecnologia.length == 0) {
            this.toastrService.warning("Informe as Tecnologias que o Candidato tem conhecimento.");
            return;
        }

        let entrevistaDto: EntrevistaCriar = new EntrevistaInfo(0, this.vagaAtualId,this.candidatoAtualId, new Date(), [], []);
        for (var _i = 0; _i < this.selectedTecnologia.length; _i++) {
            entrevistaDto.listaEntrevistaTecnologia.push({ vagaTecnologiaId: this.selectedTecnologia[_i] });

        }

        this.entrevistaService.save(entrevistaDto)
            .subscribe(res => {
                console.log(res);
                this.toastrService.success('Entrevista Cadastrada com Sucesso.');
                this.loadData();
            });
        this.displayDialog = false;
    }

    showDialogToDetail(entrevista: Entrevista) {
        this.displayDialog = false;

        this.entrevistaService.getById(entrevista.entrevistaId).subscribe(res => {
            this.entrevista = res;
        });

        this.displayDialogDetail = true;
    }


    voltar() {
        this.entrevista = new EntrevistaInfo(0, 0, 0, new Date(), [], []);
        this.displayDialog = false;
        this.displayDialogDetail = false;
        this.selectedTecnologia = [];
    }
}