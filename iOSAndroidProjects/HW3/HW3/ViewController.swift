//
//  ViewController.swift
//  HW3
//
//  Created by Rehum Padua on 2/1/17.
//  Copyright © 2017 Rehum Padua. All rights reserved.
//

import UIKit
import AVFoundation

class ViewController: UIViewController,UIPickerViewDataSource,UIPickerViewDelegate {
    
    
    
    
    @IBOutlet weak var ImageEY: UIImageView!
    @IBOutlet weak var SpanishPicker: UIPickerView!
    let SpanishData = [["Uno","Dos","Tres","Cuatro","Cinco","Seis","Siete","Ocho","Nueve"],["One","Two","Three","Four","Five","Six","Seven","Eight","Nine"]]
    func pickerView(_ pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int {
        return SpanishData[component].count
    }
    func numberOfComponents(in pickerView: UIPickerView) -> Int {
        return SpanishData.count
    }
    func pickerView(_ pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {
        return SpanishData[component][row]
    }
    func pickerView(_ pickerView: UIPickerView, didSelectRow row: Int, inComponent component: Int) {
        getSpanish()
    }
    func getSpanish()
    {
        
        
    }
    @IBAction func EnglishTime(_ sender: Any) {
        let Spanish = SpanishData[1][SpanishPicker.selectedRow(inComponent: 1)]
        speak(say:Spanish, voice:"en-US")
    }
    @IBAction func SpanishTime(_ sender: Any) {
        //let English = SpanishData[0][SpanishPicker.selectedRow(inComponent: 0)]
        let Spanish = SpanishData[0][SpanishPicker.selectedRow(inComponent: 0)]
        speak(say:Spanish, voice:"es-ES")
    }
    func speak(say:String, voice:String) {
        let utterance = AVSpeechUtterance(string:say)
        utterance.voice = AVSpeechSynthesisVoice(language: voice)
        
        let synthesizer = AVSpeechSynthesizer()
        utterance.rate = 0.4
        synthesizer.speak(utterance)
    }
    @IBAction func Matchedit(_ sender: Any) {
        let a = SpanishPicker.selectedRow(inComponent: 1)
        let b = SpanishPicker.selectedRow(inComponent: 0)
        if(a == b)
        {
            let c = "You got it righy! You are a young pup in Computer Science that's going to make a lot of money"
            speak(say: c, voice: "en-GB")
            ImageEY.image = #imageLiteral(resourceName: "Evangelos-Yfantis")
        }
        else
        {
            let c = "You got it wrong, but that's okay. Does this upset you?. should you fix it before a translator comes in and embarrases all of us?"
            speak(say: c, voice: "en-GB")
            ImageEY.image = #imageLiteral(resourceName: "EY1")
        }
    }
    

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        SpanishPicker.dataSource = self
        SpanishPicker.delegate = self
        
    }
    

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    


}

