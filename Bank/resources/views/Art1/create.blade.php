<h1>Create</h1>

<h4>Art1</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form method="post" action="/art1/dodawanie">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label for="{{$Art1->Title}}" class="control-label"></label>
                <input for="{{$Art1->Title}}" class="form-control" />
                <span for="{{$Art1->Title}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Nazwa1}}" class="control-label"></label>
                <input for="{{$Art1->Nazwa1}}" class="form-control" />
                <span for="{{$Art1->Nazwa1}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Nazwa2}}" class="control-label"></label>
                <input for="{{$Art1->Nazwa2}}" class="form-control" />
                <span for="{{$Art1->Nazwa2}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Nazwa3}" class="control-label"></label>
                <input for="{{$Art1->Nazwa3}" class="form-control" />
                <span for="{{$Art1->Nazwa3}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Grafika1}}" class="control-label"></label>
                <input for="{{$Art1->Grafika1}}" class="form-control" />
                <span for="{{$Art1->Grafika1}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Grafika2}}" class="control-label"></label>
                <input for="{{$Art1->Grafika2}}" class="form-control" />
                <span for="{{$Art1->Grafika2}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Grafika3}}" class="control-label"></label>
                <input for="{{$Art1->Grafika3}}" class="form-control" />
                <span for="{{$Art1->Grafika3}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Opis1}}" class="control-label"></label>
                <input for="{{$Art1->Opis1}}" class="form-control" />
                <span for="{{$Art1->Opis1}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Opis2}}" class="control-label"></label>
                <input for="{{$Art1->Opis2}}" class="form-control" />
                <span for="{{$Art1->Opis2}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Opis3}}" class="control-label"></label>
                <input for="{{$Art1->Opis3}}" class="form-control" />
                <span for="{{$Art1->Opis3}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label for="{{$Art1->Podsumowanie}}" class="control-label"></label>
                <input for="{{$Art1->Podsumowanie}}" class="form-control" />
                <span for="{{$Art1->Podsumowanie}}" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Create" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Back to List</a>
</div>