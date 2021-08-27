window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
});

const localApi = 'http://localhost:7071/api/countfn';
const functionApi = 'https://nresumepage.azurewebsites.net/api/countfn'

    const getVisitCount = () => {
        
        fetch(functionApi)
        .then(response => {
            return response.json()
        })
        .then(response => {
            console.log("Website called function API.");
            count = response.visitorcount;
            document.getElementById('counter').innerText = visitorcount;
        }).catch(function(error) {
            console.log(error);
          });
        return visitorcount;
    }
   