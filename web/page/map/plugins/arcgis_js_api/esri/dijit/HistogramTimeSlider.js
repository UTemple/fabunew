// All material copyright ESRI, All Rights Reserved, unless otherwise specified.
// See http://js.arcgis.com/3.16/esri/copyright.txt for details.
//>>built
require({cache:{"url:dojox/form/resources/HorizontalRangeSlider.html":'\x3ctable class\x3d"dijit dijitReset dijitSlider dijitSliderH dojoxRangeSlider" cellspacing\x3d"0" cellpadding\x3d"0" border\x3d"0" rules\x3d"none" dojoAttachEvent\x3d"onkeypress:_onKeyPress,onkeyup:_onKeyUp" role\x3d"presentation"\r\n\t\x3e\x3ctr class\x3d"dijitReset"\r\n\t\t\x3e\x3ctd class\x3d"dijitReset" colspan\x3d"2"\x3e\x3c/td\r\n\t\t\x3e\x3ctd dojoAttachPoint\x3d"topDecoration" class\x3d"dijitReset dijitSliderDecoration dijitSliderDecorationT dijitSliderDecorationH"\x3e\x3c/td\r\n\t\t\x3e\x3ctd class\x3d"dijitReset" colspan\x3d"2"\x3e\x3c/td\r\n\t\x3e\x3c/tr\r\n\t\x3e\x3ctr class\x3d"dijitReset"\r\n\t\t\x3e\x3ctd class\x3d"dijitReset dijitSliderButtonContainer dijitSliderButtonContainerH"\r\n\t\t\t\x3e\x3cdiv class\x3d"dijitSliderDecrementIconH" tabIndex\x3d"-1" style\x3d"display:none" dojoAttachPoint\x3d"decrementButton"\x3e\x3cspan class\x3d"dijitSliderButtonInner"\x3e-\x3c/span\x3e\x3c/div\r\n\t\t\x3e\x3c/td\r\n\t\t\x3e\x3ctd class\x3d"dijitReset"\r\n\t\t\t\x3e\x3cdiv class\x3d"dijitSliderBar dijitSliderBumper dijitSliderBumperH dijitSliderLeftBumper" dojoAttachEvent\x3d"onmousedown:_onClkDecBumper"\x3e\x3c/div\r\n\t\t\x3e\x3c/td\r\n\t\t\x3e\x3ctd class\x3d"dijitReset"\r\n\t\t\t\x3e\x3cinput dojoAttachPoint\x3d"valueNode" type\x3d"hidden" ${!nameAttrSetting}\r\n\t\t\t/\x3e\x3cdiv role\x3d"presentation" class\x3d"dojoxRangeSliderBarContainer" dojoAttachPoint\x3d"sliderBarContainer"\r\n\t\t\t\t\x3e\x3cdiv class\x3d"dijitSliderMoveable dijitSliderMoveableH"\r\n\t\t\t\t\t\x3e\x3cdiv class\x3d"dijitSliderImageHandle dijitSliderImageHandleH" dojoAttachPoint\x3d"sliderHandle,focusNode" tabIndex\x3d"${tabIndex}" dojoAttachEvent\x3d"onmousedown:_onHandleClick" role\x3d"slider"\x3e\x3c/div\r\n\t\t\t\t\x3e\x3c/div\r\n\t\t\t\t\x3e\x3cdiv role\x3d"presentation" dojoAttachPoint\x3d"progressBar" class\x3d"dijitSliderBar dijitSliderBarH dijitSliderProgressBar dijitSliderProgressBarH" dojoAttachEvent\x3d"onmousedown:_onBarClick"\x3e\x3c/div\r\n\t\t\t\t\x3e\x3cdiv class\x3d"dijitSliderMoveable dijitSliderMoveableH"\r\n\t\t\t\t\t\x3e\x3cdiv class\x3d"dijitSliderImageHandle dijitSliderImageHandleH" dojoAttachPoint\x3d"sliderHandleMax" tabIndex\x3d"${tabIndex}" dojoAttachEvent\x3d"onmousedown:_onHandleClickMax" role\x3d"slider"\x3e\x3c/div\r\n\t\t\t\t\x3e\x3c/div\r\n\t\t\t\t\x3e\x3cdiv role\x3d"presentation" dojoAttachPoint\x3d"remainingBar" class\x3d"dijitSliderBar dijitSliderBarH dijitSliderRemainingBar dijitSliderRemainingBarH" dojoAttachEvent\x3d"onmousedown:_onRemainingBarClick"\x3e\x3c/div\r\n\t\t\t\x3e\x3c/div\r\n\t\t\x3e\x3c/td\r\n\t\t\x3e\x3ctd class\x3d"dijitReset"\r\n\t\t\t\x3e\x3cdiv class\x3d"dijitSliderBar dijitSliderBumper dijitSliderBumperH dijitSliderRightBumper" dojoAttachEvent\x3d"onmousedown:_onClkIncBumper"\x3e\x3c/div\r\n\t\t\x3e\x3c/td\r\n\t\t\x3e\x3ctd class\x3d"dijitReset dijitSliderButtonContainer dijitSliderButtonContainerH"\r\n\t\t\t\x3e\x3cdiv class\x3d"dijitSliderIncrementIconH" tabIndex\x3d"-1" style\x3d"display:none" dojoAttachPoint\x3d"incrementButton"\x3e\x3cspan class\x3d"dijitSliderButtonInner"\x3e+\x3c/span\x3e\x3c/div\r\n\t\t\x3e\x3c/td\r\n\t\x3e\x3c/tr\r\n\t\x3e\x3ctr class\x3d"dijitReset"\r\n\t\t\x3e\x3ctd class\x3d"dijitReset" colspan\x3d"2"\x3e\x3c/td\r\n\t\t\x3e\x3ctd dojoAttachPoint\x3d"containerNode,bottomDecoration" class\x3d"dijitReset dijitSliderDecoration dijitSliderDecorationB dijitSliderDecorationH"\x3e\x3c/td\r\n\t\t\x3e\x3ctd class\x3d"dijitReset" colspan\x3d"2"\x3e\x3c/td\r\n\t\x3e\x3c/tr\r\n\x3e\x3c/table\x3e\r\n',
"url:esri/dijit/HistogramTimeSlider/templates/HistogramTimeSlider.html":'\x3cdiv id\x3d"histogram-timeslider" class\x3d"histogram-timeslider esriTimeSlider"\x3e\r\n \x3cdiv id\x3d"histogram-timeslider-dijit"\x3e\r\n   \x3cdiv id\x3d"focusTip"\x3e\x3c/div\x3e\r\n   \x3cdiv id\x3d"scale-bar-left"\x3e\x3c/div\x3e\r\n   \x3cdiv id\x3d"scale-bar-right"\x3e\x3c/div\x3e\r\n   \x3cdiv id\x3d"histogram-container"\x3e\x3c/div\x3e\r\n   \x3cdiv id\x3d"histogram-slider"\x3e\x3c/div\x3e\r\n   \x3cdiv id\x3d"histogram-controls"\x3e\r\n     \x3cdiv id\x3d"histogram-range"\x3e\x3c/div\x3e\r\n   \x3c/div\x3e\r\n  \x3c/div\x3e\r\n\x3c/div\x3e'}});
define("esri/dijit/HistogramTimeSlider","../kernel ../lang ../TimeExtent dijit/_TemplatedMixin dijit/_WidgetBase dijit/form/HorizontalSlider dojo/_base/array dojo/_base/connect dojo/_base/declare dojo/_base/lang dojo/dom dojo/dom-style dojo/has dojo/string dojox/gfx dojox/form/RangeSlider dojo/i18n!../nls/jsapi dojo/text!dojox/form/resources/HorizontalRangeSlider.html dojo/text!./HistogramTimeSlider/templates/HistogramTimeSlider.html".split(" "),function(v,l,w,m,x,y,r,p,s,z,n,A,B,t,q,C,u,D,E){m=s([x,
m],{declaredClass:"esri.dijit.HistogramTimeSlider",templateString:E,constructor:function(a,c){var b=this;this.layers=a.layers;this.element=c;this.bins=[];this.fullTimeExtent=[];this._mode=a.mode||"show_partial";this._resolution="esriTimeUnitsSeconds";this._timeInterval=a.timeInterval;this._numeric_res=36E5;this._max_bins=400;this._max_bin_height=this._prev_num_bins=0;this._color=a.color||"rgb(5, 112, 176)";this.is_streaming=this._active=!1;this.load_count=0;this._textColor=a.textColor||"rgb(82, 95, 109)";
this.timeField=a.timeField;this.dateFormat=a.dateFormat||"DateString";this._dateTemplate="${date: "+this.dateFormat+"}";this._wire();this._resolutions={esriTimeUnitsSeconds:[0],esriTimeUnitsMinutes:[0],esriTimeUnitsHours:[0],esriTimeUnitsDays:[0],esriTimeUnitsMonths:[0],esriTimeUnitsYears:[0]};this._num_resolutions={esriTimeUnitsSeconds:1E3,esriTimeUnitsMinutes:6E4,esriTimeUnitsHours:36E5,esriTimeUnitsDays:864E5,esriTimeUnitsMonths:2592E6,esriTimeUnitsYears:31536E6};r.forEach(this.layers,function(a,
c){if(a.url)var g=a.on("update-end",function(){p.disconnect(g);var c,e;b.fullTimeExtent=b.getFullTimeExtent();if(a.graphics){b.updateLength=a.graphics.length;c=0;for(e=a.graphics.length;c<e;c++)b._add(a.graphics[c].attributes[a.timeInfo.startTimeField])}});else b._bindStreamingEvents(a)})},getFullTimeExtent:function(){var a=null,c=null,b,d;b=0;for(d=this.layers.length;b<d;b++)if(this.layers[b].timeInfo.timeExtent.startTime){var e=this.layers[b].timeInfo.timeExtent.startTime.getTime(),g=this.layers[b].timeInfo.timeExtent.endTime.getTime();
a?a>e?a=e:c<g&&(c=g):(a=e,c=g)}return[a,c]},getCurrentTimeExtent:function(){},_wire:function(){var a=this;p.connect(window,"onmouseup, blur",function(){a._active&&a.bins.length!==a._prev_num_bins&&(a._active=!1,a._prev_num_bins=a.bins.length,a._drawHistogram(),a._updateSlider())});p.connect(window,"resize",function(){a._prev_num_bins=a.bins.length;a._drawHistogram();a._updateSlider()})},_bindStreamingEvents:function(a){var c=this;a.on("graphic-draw",function(a){c.is_streaming=!0;c._add(a.graphic.attributes[c.timeField])});
a.on("graphic-remove",function(a){c.is_streaming=!0;a=a.graphic.attributes[c.timeField];"show_partial"===c._mode&&c._remove(a)})},_nextRes:function(){for(var a in this._resolutions)if(this._resolutions[a].length<=this._max_bins)return a},_updateAllResolutions:function(a,c){var b=this._timeInterval||this._resolution,d=this._num_resolutions[b]/1E3,e=Math.floor(a*d/60),g=Math.floor(a*d/3600),h=Math.floor(a*d/86400),k=Math.floor(a*d/2592E3),d=Math.floor(a*d/31536E3);if("esriTimeUnitsSeconds"===b){var f=
a-this._resolutions.esriTimeUnitsSeconds.length;if(1<=f)for(b=0;b<f;b++)this._resolutions.esriTimeUnitsSeconds.push(0);this._resolutions.esriTimeUnitsSeconds[a]||(this._resolutions.esriTimeUnitsSeconds[a]=0);!c?this._resolutions.esriTimeUnitsSeconds[a]++:this._resolutions.esriTimeUnitsSeconds[a]--}if("esriTimeUnitsHours"!==this._timeInterval){f=e-this._resolutions.esriTimeUnitsMinutes.length;if(1<=f)for(b=0;b<f;b++)this._resolutions.esriTimeUnitsMinutes.push(0);this._resolutions.esriTimeUnitsMinutes[e]||
(this._resolutions.esriTimeUnitsMinutes[e]=0);!c?this._resolutions.esriTimeUnitsMinutes[e]++:this._resolutions.esriTimeUnitsMinutes[e]--}f=g-this._resolutions.esriTimeUnitsHours.length;if(1<=f)for(b=0;b<f;b++)this._resolutions.esriTimeUnitsHours.push(0);this._resolutions.esriTimeUnitsHours[g]||(this._resolutions.esriTimeUnitsHours[g]=0);!c?this._resolutions.esriTimeUnitsHours[g]++:this._resolutions.esriTimeUnitsHours[g]--;f=h-this._resolutions.esriTimeUnitsDays.length;if(1<=f)for(b=0;b<f;b++)this._resolutions.esriTimeUnitsDays.push(0);
this._resolutions.esriTimeUnitsDays[h]||(this._resolutions.esriTimeUnitsDays[h]=0);!c?this._resolutions.esriTimeUnitsDays[h]++:this._resolutions.esriTimeUnitsDays[h]--;f=k-this._resolutions.esriTimeUnitsMonths.length;if(1<=f)for(b=0;b<f;b++)this._resolutions.esriTimeUnitsMonths.push(0);this._resolutions.esriTimeUnitsMonths[k]||(this._resolutions.esriTimeUnitsMonths[k]=0);!c?this._resolutions.esriTimeUnitsMonths[k]++:this._resolutions.esriTimeUnitsMonths[k]--;f=d-this._resolutions.esriTimeUnitsYears.length;
if(1<=f)for(b=0;b<f;b++)this._resolutions.esriTimeUnitsYears.push(0);this._resolutions.esriTimeUnitsYears[d]||(this._resolutions.esriTimeUnitsYears[d]=0);!c?this._resolutions.esriTimeUnitsYears[d]++:this._resolutions.esriTimeUnitsYears[d]--;!this._timeInterval&&this._resolutions[this._resolution].length>=this._max_bins&&(this._resolution=this._nextRes());b=0;switch(this._resolution){case "esriTimeUnitsSeconds":b=a;this._numeric_res=1E3;break;case "esriTimeUnitsMinutes":b=e;this._numeric_res=6E4;break;
case "esriTimeUnitsHours":b=g;this._numeric_res=36E5;break;case "esriTimeUnitsDays":b=h;this._numeric_res=864E5;break;case "esriTimeUnitsMonths":b=k;this._numeric_res=2592E6;break;case "esriTimeUnitsYears":b=d,this._numeric_res=31536E6}this._setBins(b)},_setBins:function(a){this.bins=this._resolutions[this._timeInterval||this._resolution];for(var c=0,b=0;0===this.bins[b];)c=b+1,b+=1;if(this._active)c!==this.minVisibleIndex&&(this.minVisibleIndex=c);else if(!this.is_streaming&&this.updateLength===
this.load_count){if(this.bins.length!==this._prev_num_bins||c!==this.minVisibleIndex)this.minVisibleIndex=c,this._prev_num_bins=this.bins.length,this._drawHistogram(),this._slider&&this._updateSlider()}else this.is_streaming&&(this.bins.length!=this._prev_num_bins||c!=this.minVisibleIndex)?(this.minVisibleIndex=c,this._prev_num_bins=this.bins.length,this._drawHistogram(),this._slider&&this._updateSlider()):this.is_streaming&&this._updateHeights(a)},_updateFullTimeExtent:function(a){this.fullTimeExtent[0]||
(this.fullTimeExtent[0]=a);this.fullTimeExtent[1]||(this.fullTimeExtent[1]=a);a<this.fullTimeExtent[0]&&(this.fullTimeExtent[0]=a);a>this.fullTimeExtent[1]&&(this.fullTimeExtent[1]=a)},_getBin:function(a){return Math.floor((a-this.fullTimeExtent[0])/this._num_resolutions[this._timeInterval||this._resolution])},_add:function(a){var c=this._timeInterval||this._resolution;this.is_streaming||this.load_count++;this._updateFullTimeExtent(a);a=this._getBin(a);var b=a-this._resolutions[c].length,d;if(1<=
b)for(d=0;d<b;d++)this._resolutions[c].push(0);this._updateAllResolutions(a);this._slider||this._createSlider()},_remove:function(a){a=this._getBin(a);this._resolutions.esriTimeUnitsSeconds[a]--;this._updateAllResolutions(a,!0);this._active||this._updateSlider()},_createSlider:function(){var a=this;this._slider=new (s([y,C],{templateString:D}))({name:"histogram-slider",values:[0,100],minimum:0,maximum:100,showButtons:!1,intermediateChanges:!0,discreteValues:2,style:"width:100%",onChange:function(c){var b=
Math.floor(c[0]);c=Math.floor(c[1]);a._getUserExtents(b,c);a._disableBins(b,c)}},"histogram-slider")},_updateSlider:function(){this._slider.discreteValues=this.histogram.length+1;this._slider.maximum=this.histogram.length;this._slider._setValueAttr([0,this.histogram.length],!1,!1)},_getUserExtents:function(a,c){var b=this._timeInterval||this._resolution,d=new w;d.startTime=new Date(this.fullTimeExtent[0]+(a+this.minVisibleIndex)*this._num_resolutions[b]);d.endTime=new Date(this.fullTimeExtent[0]+
(c+this.minVisibleIndex)*this._num_resolutions[b]);this._updateDateRange(d);this.onTimeExtentChange(d)},_drawHistogram:function(){var a=this,c=[];this.histogramSurface?this.histogramSurface.clear():this.histogramSurface=q.createSurface("histogram-container",n.byId(this.element.id).offsetWidth,100);var b=Math.max.apply(Math,this.bins),d=this.histogramSurface._parent.clientWidth/(this.bins.length-this.minVisibleIndex),e=d/10,g=0;this.histogram=[];var h,k;h=this.minVisibleIndex;for(k=this.bins.length;h<
k;h++){var f=100*(this.bins[h]/b),f=this.histogramSurface.createRect({x:g,y:100-f,width:d-e,height:f}).setFill(this._color);this.histogram.push(f);g+=d;c.push(g);f.bin=this.bins[h];f.x=g-d;f.num=h;f.max=b;f.on("mouseover",function(b){a._showTipForBin(b.gfxTarget.bin,b.gfxTarget.num,b.gfxTarget.x)});f.on("mouseout",function(){a._hideTipForBin()})}this._updateTimeTicks(c);this._updateScaleBar(b);this.onUpdate()},_updateHeights:function(a){var c=Math.max.apply(Math,this.bins),b,d,e;if(c!==this._max_bin_height){d=
this.minVisibleIndex;for(e=this.histogram.length;d<e;d++)b=100*(this.bins[d]/c),a=100-b,this.histogram[d].setShape({y:a,height:b})}else b=100*(this.bins[a]/c),this.histogram[a-this.minVisibleIndex].setShape({y:100-b,height:b});this._updateScaleBar(c);this._max_bin_height=c},_updateTimeTicks:function(a){var c=this._timeInterval||this._resolution,b=Math.floor(this.histogram.length/3),d,e;for(e=0;2>e;e++)this.histogramSurface.createLine({x1:a[b],y1:0,x2:a[b],y2:this.histogramSurface._parent.clientHeight}).setStroke(this._textColor),
d=new Date(this.fullTimeExtent[0]+(b+1-this.minVisibleIndex)*this._num_resolutions[c]),d=l.substitute({date:d.getTime()},this._dateTemplate),this.histogramSurface.createText({x:a[b]+2,y:10,text:d}).setFont({size:"12px"}).setFill(this._textColor),b+=b},_updateDateRange:function(a){var c=l.substitute({date:(new Date(a.startTime)).getTime()},this._dateTemplate);a=l.substitute({date:(new Date(a.endTime)).getTime()},this._dateTemplate);c=t.substitute(u.widgets.HistogramTimeSlider.dateRange,{start:c,end:a});
n.byId("histogram-range").innerHTML=c},_disableBins:function(a,c){var b=this;0===a&&c===this.histogram.length?(this.histogram[0].setFill(this._color),this.histogram[this.histogram.length-1].setFill(this._color)):r.forEach(this.histogram,function(d,e){e<a?d.setFill("rgb(216,216,216)"):e>=c?d.setFill("rgb(216,216,216)"):d.setFill(b._color)})},_updateScaleBar:function(a){this.scaleLeft?(this.scaleLeft.clear(),this.scaleRight.clear()):(this.scaleRight=q.createSurface("scale-bar-right",45,110),this.scaleLeft=
q.createSurface("scale-bar-left",45,110));var c,b;c=99<a?10:20;b=99<a/2?b=10:20;this.scaleLeft.createLine({x1:40,y1:5,x2:40,y2:130}).setStroke("rgb(82, 95, 109)");this.scaleLeft.createLine({x1:40,y1:5,x2:37,y2:5}).setStroke("rgb(82, 95, 109)");this.scaleLeft.createLine({x1:40,y1:60,x2:37,y2:60}).setStroke("rgb(82, 95, 109)");this.scaleLeft.createText({x:c,y:10,text:a}).setFont({size:"14px"}).setFill(this._textColor);this.scaleLeft.createText({x:b,y:65,text:Math.floor(a/2)}).setFont({size:"14px"}).setFill(this._textColor);
this.scaleRight.createLine({x1:0,y1:5,x2:0,y2:130}).setStroke("rgb(82, 95, 109)");this.scaleRight.createLine({x1:0,y1:5,x2:3,y2:5}).setStroke("rgb(82, 95, 109)");this.scaleRight.createLine({x1:0,y1:60,x2:3,y2:60}).setStroke("rgb(82, 95, 109)");this.scaleRight.createText({x:4,y:10,text:a}).setFont({size:"14px"}).setFill(this._textColor);this.scaleRight.createText({x:4,y:65,text:Math.floor(a/2)}).setFont({size:"14px"}).setFill(this._textColor)},_showTipForBin:function(a,c,b){var d=this._timeInterval||
this._resolution;if(!this._active){var e=new Date(this.fullTimeExtent[0]+(c-this.minVisibleIndex)*this._num_resolutions[d]),e=l.substitute({date:e.getTime()},this._dateTemplate);c=new Date(this.fullTimeExtent[0]+(c+1-this.minVisibleIndex)*this._num_resolutions[d]);c=l.substitute({date:c.getTime()},this._dateTemplate);a=t.substitute(u.widgets.HistogramTimeSlider.count,{count:a});n.byId("focusTip").innerHTML="\x3cspan style\x3d'font-size:8pt'\x3e"+e+" to "+c+"\x3c/span\x3e \x3cbr /\x3e "+a;A.set("focusTip",
{display:"block",left:b+"px",top:"-10px"})}},_hideTipForBin:function(){n.byId("focusTip").style.display="none"},onTimeExtentChange:function(){},onUpdate:function(){}});B("extend-esri")&&z.setObject("dijit.HistogramTimeSlider",m,v);return m});