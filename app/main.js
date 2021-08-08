


const localApi = 'http://localhost:7071/api/VisitorCount';
const functionApi = 'https://nresumepage.azurewebsites.net/api/visitorcountfn?'

    fetch(functionApi)
    .then(response => {
        return response.json()
    })
    .then(response => {
        console.log("Website called function API.");
        Count = response.count;
        document.getElementById('Counter').innerText = 'You are vistor number' + Count ;
    }).catch(function(error) {
        console.log("D for damage");
      });
   