'use strict;'

const https = require('https');

let html = "";

https.get('https://ilmatieteenlaitos.fi/saa/turku?forecast=short', (res) => {
  console.log('statusCode:', res.statusCode);
  console.log('headers:', res.headers);

  res.on('data', (d) => {
	  html = html+d;
	
	let indeksi = html.indexOf('temperature-container');
	//console.log("Indeksi = "+indeksi);
	
	indeksi = indeksi + 75;
	var res = html.substring(indeksi,indeksi+5);
	console.log(res);
  });

}).on('error', (e) => {
  console.error(e);
});




/*
const fetch = require("node-fetch");

(async () => {
  const response = await fetch('https://ilmatieteenlaitos.fi/saa/turku?forecast=short');
  const text = await response.text();
  console.log(text.match((?<=\"Lämpötila)*?(?=C)d);
})()
*/