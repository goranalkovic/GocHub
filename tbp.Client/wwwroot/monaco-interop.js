var editors = [];
var globalDiffEditor = null;
var globalDiffEditorId = null;

window.newDiffEditor =
    function(id, language, originalContent, modifiedContent) {

        var diffEditor = monaco.editor.createDiffEditor(document.getElementById(id),
            {
                wordWrap: true,
                roundedSelection: true,
                fontFamily: "Fira Code",
                fontLigatures: true,
                fontSize: 11.5,
                readOnly: true
            });

        diffEditor.setModel({
            original: monaco.editor.createModel(modifiedContent, language),
            modified: monaco.editor.createModel(originalContent, language)
        });

        globalDiffEditor = diffEditor;
        globalDiffEditorId = id;

        return true;
    }


window.newEditor =
function(id, language, value) {

    var editor = monaco.editor.create(document.getElementById(id),
        {
            value: value,
            language: language,
            wordWrap: true,
            roundedSelection: true,
            fontFamily: "Fira Code",
            fontLigatures: true,
            fontSize: 11.5
        });

    editors.push({ id: id, editor: editor });

    return true;
}

window.setLanguage = function(id, newLang) {
    let found = editors.find(e => e.id === id);
    var value = found.editor.getValue();

    if (!found) return false;

    found.editor.dispose();

    found.editor = monaco.editor.create(document.getElementById(id),
        {
            value: value,
            language: newLang,
            wordWrap: true,
            roundedSelection: true,
            fontFamily: "Fira Code",
            fontLigatures: true,
            fontSize: 13.0,
            automaticLayout: true
        });

    return true;
}

window.setData = function(id, newData) {
    let found = editors.find(e => e.id === id);

    if (!found) return false;

    found.editor.setValue(newData);

    return true;
}

window.getData = function(id) {
    let found = editors.find(e => e.id === id);

    if (!found) return false;
    return btoa(found.editor.getValue());
}

window.removeEditor = function(id) {
    let found = editors.find(e => e.id === id);
    let index = editors.indexOf(found);
    
    if (!found) return false;
    
    found.id = null;
    found.editor.dispose();
    found.editor = null;

    editors.splice(index, 1);

    return true;
}

window.removeDiffEditor = function(id) {
    globalDiffEditor.dispose();
    globalDiffEditor = null;
    globalDiffEditorId = null;

    return true;
}

window.clearEditors = function() {
    editors.clear();
    return true;
}

window.doesEditorExist = function(id) {
    const found = editors.find(e => e.id === id);

    if (!found)
        return false;
    else 
        return true;
}

window.doesDiffEditorExist = function(id) {
    const found = id === globalDiffEditorId;

    if (!found)
        return false;
    else 
        return true;
}