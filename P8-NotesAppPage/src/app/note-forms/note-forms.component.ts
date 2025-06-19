import { AfterViewInit, Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { UpdateNoteCommand } from '../_interfaces/Note/UpdateNoteCommand';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CategoryService } from '../Service/category.service';
import { Category } from '../_interfaces/Category/Category';
import { _isNumberValue } from '@angular/cdk/coercion';
import { NoteService } from '../Service/note.service';
import { CreateNoteCommand } from '../_interfaces/Note/CreateNoteCommand';
import { Note } from '../_interfaces/Note/Note';

@Component({
  selector: 'app-note-forms',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatDatepickerModule, MatNativeDateModule, 
    MatButtonModule, RouterLink],
  templateUrl: './note-forms.component.html',
  styleUrl: './note-forms.component.css'
})
export class NoteFormsComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    this.activatedRoute.params.subscribe(params => { this.id = +params['id'];});
    if(_isNumberValue(this.id)){
      this.noteService.getById(this.id).subscribe((res: Note)=>{
        this.model = {id: this.id, name: res.name, categoryId: res.categoryId, identityUserId:""};
        this.categoryServices.get().subscribe((res: Category[])=>{
          this.listCategory = res;
          this.selectedCategory = this.model!.categoryId!;
        });
        this.form.patchValue(this.model!);
      })
    }
    else{
      this.categoryServices.get().subscribe((res: Category[])=>{
        this.listCategory = res;
        this.selectedCategory = this.listCategory[0].id;
      });
    }
  }
  @Input({required: true})
  Titulo!: string;
  @Input({required: true})
  ButtonName!: string;
  @Input()
  model!: UpdateNoteCommand | undefined;
  @Input({transform: numberAttribute})
  id! : number;

  listCategory!: Category[];
  selectedCategory!: number;
  private activatedRoute = inject(ActivatedRoute);
  private categoryServices = inject(CategoryService);
  private noteService = inject(NoteService);
  private formBuilder = inject(FormBuilder);
  private route = inject(Router);
  form = this.formBuilder.group({
    name: ['', {validators: [Validators.required, Validators.maxLength(50)]}], 
    category: ['', {validators: [Validators.required]}]
  });
  guardarCambios(){
    if(_isNumberValue(this.id)){
      let note: UpdateNoteCommand = {id: this.id, categoryId: Number(this.form.controls.category.value), 
        name: this.form.controls.name.value!, identityUserId: ""}
      this.noteService.update(this.id, note).subscribe({
        next:()=>{
          this.route.navigate([`menu`])
        },
        error:()=>{
          alert("Error al updatear NOTE");
        }
      })
    }
    else{
      let note: CreateNoteCommand = {categoryId: Number(this.form.controls.category.value), name: this.form.controls.name.value!, 
        identityUserId: ""}
        this.noteService.create(note).subscribe({
          next:()=>{
            this.route.navigate([`menu`])
          },
          error:()=>{
            alert("Error al crear NOTE");
          }
        })
    }
  }
  ErrorCampoGenerico(control: FormControl): string {
      if (control.hasError('required')) {
        return "Por favor complete este campo";
      }
      if (control.hasError('maxlength')) {
        return `El texto supera el limite de ${control.getError('maxlength').requiredLength} caracteres`;
      }
      return "";
  }
}
