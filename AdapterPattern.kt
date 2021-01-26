// Target
interface IAircraft {
    fun fly(): Unit
}

// Adaptee
class HotAirBalloon {

    private var gasUsed: String = "helium"

    fun fly(gasUsed: String): Unit {
        println("Hot Air Balloon Flying using $gasUsed")
    }

    fun inflateWithGas(): String {
        return this.gasUsed;
    }
}

// Adapter
class HotAirBalloonAdapter(private val hotAirBalloon: HotAirBalloon) : IAircraft {

    override fun fly() {
        val fuelUsed: String = this.hotAirBalloon.inflateWithGas();
        hotAirBalloon.fly(fuelUsed);
    }
}

// Client
fun main(args: Array<String>) {

    val hotAirBalloon = HotAirBalloon();
    val hotAirBalloonAdapter = HotAirBalloonAdapter(hotAirBalloon);

    hotAirBalloonAdapter.fly();
}
