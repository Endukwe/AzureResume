


const localApi = 'http://localhost:7071/api/VisitorCount';
const functionApi = 'https://resumepage.azurewebsites.net/api/VisitorCount?code=I5VuMTUExKek0wEa7gJ5IS9eBybqYnxDpiPHJhnTWPaU3TbLiQPUdQ=='; 


    fetch(functionApi)
    .then(response => {
        return response.json()
    })
    .then(response => {
        console.log("Website called function API.");
        Count = response.count;
        document.getElementById('Counter').innerText = 'You are vistor number' + Count ;
    }).catch(function(error) {
        console.log(error);
      });
   