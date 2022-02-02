interface IObservable {
    fun add(observer: IObserver)
    fun remove(observer: IObserver)
    fun notifyObservers()
}


class WeatherStation : IObservable {
    val observers: MutableList<IObserver> = mutableListOf()
    var temperature: Int = 10
    	get() = field
    	set(value) { field = value }
    
    override fun add(observer: IObserver): Unit {
        this.observers.add(observer)
    }
    
     override fun remove(observer: IObserver): Unit {
        this.observers.remove(observer)
    }
     
     override fun notifyObservers(): Unit {
         this.observers.forEach{
             it.update()
         }
     } 
}


interface IObserver {
    fun update(): Unit
}

class PhoneDisplay (weatherStation: WeatherStation) : IObserver {
    lateinit var weatherStation : WeatherStation
    
    init {
        this.weatherStation = weatherStation
    }
    
    override fun update(): Unit {
        print(this.weatherStation.temperature)
    }
}


fun main() {
   val weatherStation = WeatherStation()
   val phoneDisplay = PhoneDisplay(weatherStation)
   
   weatherStation.add(phoneDisplay)
   weatherStation.notifyObservers()
   weatherStation.temperature = 20
   weatherStation.notifyObservers()

}
