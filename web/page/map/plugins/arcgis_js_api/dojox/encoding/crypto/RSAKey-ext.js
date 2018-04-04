//>>built
define("dojox/encoding/crypto/RSAKey-ext",["dojo/_base/kernel","dojo/_base/lang","./RSAKey","../../math/BigInteger-ext"],function(m,n,l,c){m.experimental("dojox.encoding.crypto.RSAKey-ext");n.extend(l,{setPrivate:function(b,a,d){if(b&&a&&b.length&&a.length)this.n=new c(b,16),this.e=parseInt(a,16),this.d=new c(d,16);else throw Error("Invalid RSA private key");},setPrivateEx:function(b,a,d,e,f,g,h,k){if(b&&a&&b.length&&a.length)this.n=new c(b,16),this.e=parseInt(a,16),this.d=new c(d,16),this.p=new c(e,
16),this.q=new c(f,16),this.dmp1=new c(g,16),this.dmq1=new c(h,16),this.coeff=new c(k,16);else throw Error("Invalid RSA private key");},generate:function(b,a){var d=this.rngf(),e=b>>1;this.e=parseInt(a,16);for(var f=new c(a,16);;){for(;!(this.p=new c(b-e,1,d),!this.p.subtract(c.ONE).gcd(f).compareTo(c.ONE)&&this.p.isProbablePrime(10)););for(;!(this.q=new c(e,1,d),!this.q.subtract(c.ONE).gcd(f).compareTo(c.ONE)&&this.q.isProbablePrime(10)););if(0>=this.p.compareTo(this.q)){var g=this.p;this.p=this.q;
this.q=g}var g=this.p.subtract(c.ONE),h=this.q.subtract(c.ONE),k=g.multiply(h);if(!k.gcd(f).compareTo(c.ONE)){this.n=this.p.multiply(this.q);this.d=f.modInverse(k);this.dmp1=this.d.mod(g);this.dmq1=this.d.mod(h);this.coeff=this.q.modInverse(this.p);break}}d.destroy()},decrypt:function(b){var a=new c(b,16);if(!this.p||!this.q)a=a.modPow(this.d,this.n);else{b=a.mod(this.p).modPow(this.dmp1,this.p);for(a=a.mod(this.q).modPow(this.dmq1,this.q);0>b.compareTo(a);)b=b.add(this.p);a=b.subtract(a).multiply(this.coeff).mod(this.p).multiply(this.q).add(a)}if(!a)return null;
a:{b=this.n.bitLength()+7>>3;for(var a=a.toByteArray(),d=0,e=a.length;d<e&&!a[d];++d);if(a.length-d!==b-1||2!==a[d])b=null;else{for(++d;a[d];)if(++d>=e){b=null;break a}for(b="";++d<e;)b+=String.fromCharCode(a[d])}}return b}});return l});