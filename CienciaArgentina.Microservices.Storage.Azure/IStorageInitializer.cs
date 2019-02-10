using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Storage.Azure
{
	public interface IStorageInitializer
	{
		Task Initialize();
		Task Drop();
	}
}