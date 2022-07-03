
// string addition time elapsed p tag
let stringAdditionTimeElapsed = document.getElementById("string-test-time-elapsed");
// string addition div
let stringAdditionDiv = document.getElementById("string-test-div");

// string addition time elapsed p tag
let stringBuilderTimeElapsed = document.getElementById("stringbuilder-test-time-elapsed");
// string builder div
let stringBuilderDiv = document.getElementById("stringbuilder-test-div");



// string addition data
stringAdditionTimeElapsed.innerHTML = "Time Elapsed for " + stringAdditionData.NumberOfLoops + "Loops: " + stringAdditionData.Elapsed.Seconds + "Seconds (" + stringBuilderData.Elapsed.Minutes + " Minutes)";
stringAdditionData.StructureData.forEach((s) => {
    //console.log(s.Id)
    stringAdditionDiv.innerHTML += "<ul>";
    stringAdditionDiv.innerHTML += "<li style=\"background:" + s.Color + "\">" + s.Id + "</li>";
    stringAdditionDiv.innerHTML += "<li>Volume: " + s.Volume + " cc</li>";
    stringAdditionDiv.innerHTML += "<li>Max Dose: " + s.MaxDose + " Gy</li>";
    stringAdditionDiv.innerHTML += "</ul>";
});

// string builder data
stringBuilderTimeElapsed.innerHTML = "Time Elapsed for " + stringBuilderData.NumberOfLoops + "Loops: " + stringBuilderData.Elapsed.Seconds + "Seconds (" + stringBuilderData.Elapsed.Minutes + " Minutes)";


stringBuilderData.StructureData.forEach((s) => {
    //console.log(s.Id)
    stringBuilderDiv.innerHTML += "<ul>";
    stringBuilderDiv.innerHTML += "<li style=\"background:" + s.Color + "\">" + s.Id + "</li>";
    stringBuilderDiv.innerHTML += "<li>Volume: " + s.Volume + " cc</li>";
    stringBuilderDiv.innerHTML += "<li>Max Dose: " + s.MaxDose + " Gy</li>";
    stringBuilderDiv.innerHTML += "</ul>";
});